using Luxand;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VimassFVA
{
    public partial class Main : Form
    {
        // program states: whether we recognize faces, or user has clicked a face
        enum ProgramState { psRemember, psRecognize }
        ProgramState programState = ProgramState.psRecognize;

        bool needClose = false;
        String cameraName;
        string userName;
        String TrackerMemoryFile = "tracker70.dat";
        int mouseX = 0;
        int mouseY = 0;

        String fileName = "D://dataFVA.txt";

        long[] IDs_Global;         // Danh sách khuôn mặt

        bool batDauDangKi = false;

        public Main()
        {
            InitializeComponent();

        }

        private void Main_Load(object sender, EventArgs e)
        {
            String keyLX = "uypkToItYK8NviZCLG+n9L6lgekJ5n5TWWkroruVGQf+Ku3pl30qunuTAYchw" +
                "RC2MLKLubUspp+QI4BTUNHnCSiZbEcHmoOmxE4e/HTHik6bxM7I5V9LnggPEyD" +
                "w8ga1Q4IfbBE5aR4mc9RgKRz6e9y/99phHELlXK03W1zur6w=";
            if (FSDK.FSDKE_OK != FSDK.ActivateLibrary(keyLX))
            {
                MessageBox.Show("License Key Hết Hạn", "Lỗi rồi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            FSDK.InitializeLibrary();
            FSDKCam.InitializeCapturing();

            string[] cameraList;
            int count;
            FSDKCam.GetCameraList(out cameraList, out count);

            if (0 == count)
            {
                MessageBox.Show("Vui lòng cho phép sử dụng camera", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            cameraName = cameraList[0];

            FSDKCam.VideoFormatInfo[] formatList;
            FSDKCam.GetVideoFormatList(ref cameraName, out formatList, out count);
            System.Diagnostics.Debugger.Launch();
            int VideoFormat = 0; // choose a video format
            pictureBox1.Width = formatList[VideoFormat].Width;
            pictureBox1.Height = formatList[VideoFormat].Height;
            //this.Width = formatList[VideoFormat].Width + 48;
            //this.Height = formatList[VideoFormat].Height + 96;


        }

        private void btn_khoiDongCamera_Click(object sender, EventArgs e)
        {
            khoiDongCamera();
        }

        private void khoiDongCamera()
        {
            //
            int cameraHandle = 0;

            int r = FSDKCam.OpenVideoCamera(ref cameraName, ref cameraHandle);
            if (r != FSDK.FSDKE_OK)
            {
                MessageBox.Show("Lỗi mở camera thứ 1", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            int tracker = 0; 	// Tạo một Tracker
            if (FSDK.FSDKE_OK != FSDK.LoadTrackerMemoryFromFile(ref tracker, TrackerMemoryFile)) // Cố gắng tải trạng thái trình theo dõi đã lưu
                FSDK.CreateTracker(ref tracker); // Nếu không tải được, hãy tạo một trình theo dõi mới

            int err = 0; // Đặt thông số nhận diện khuôn mặt thời gian thực
            FSDK.SetTrackerMultipleParameters(tracker, "HandleArbitraryRotations=false; DetermineFaceRotationAngle=false; InternalResizeWidth=100; FaceDetectionThreshold=5;", ref err);

            while (!needClose)
            {
                Int32 imageHandle = 0;
                if (FSDK.FSDKE_OK != FSDKCam.GrabFrame(cameraHandle, ref imageHandle)) // Lấy khung hình hiện tại từ máy ảnh
                {
                    Application.DoEvents();
                    continue;
                }
                FSDK.CImage image = new FSDK.CImage(imageHandle);

                long[] IDs;         // Danh sách khuôn mặt
                long faceCount = 0;
                FSDK.FeedFrame(tracker, 0, image.ImageHandle, ref faceCount, out IDs, sizeof(long) * 1); // Tối đa 256 khuôn mặt được phát hiện
                Array.Resize(ref IDs, (int)faceCount);
                IDs_Global = IDs;
                // Làm cho các điều khiển giao diện người dùng có thể truy cập được (để tìm xem người dùng có nhấp vào một khuôn mặt hay không)
                Application.DoEvents();

                Image frameImage = image.ToCLRImage();
                Graphics gr = Graphics.FromImage(frameImage);

                for (int i = 0; i < IDs.Length; ++i)
                {
                    // Lấy ra vị trí khuôn mặt
                    FSDK.TFacePosition facePosition = new FSDK.TFacePosition();
                    FSDK.GetTrackerFacePosition(tracker, 0, IDs[i], ref facePosition);

                    int left = facePosition.xc - (int)(facePosition.w * 0.6);
                    int top = facePosition.yc - (int)(facePosition.w * 0.5);
                    int w = (int)(facePosition.w * 1.2);

                    String name;
                    int res = FSDK.GetAllNames(tracker, IDs[i], out name, 65536); // Tối đa 65536 ký tự

                    if (FSDK.FSDKE_OK == res && name.Length > 0)
                    {
                        // Vẽ tên
                        StringFormat format = new StringFormat();
                        format.Alignment = StringAlignment.Center;

                        gr.DrawString(name, new System.Drawing.Font("Arial", 16),
                            new System.Drawing.SolidBrush(System.Drawing.Color.LightGreen),
                            facePosition.xc, top + w + 5, format);
                    }

                    Pen pen = Pens.LightGreen;

                    if (ProgramState.psRemember == programState || batDauDangKi)
                    {
                        if (FSDK.FSDKE_OK == FSDK.LockID(tracker, IDs[i]))
                        {
                            // get the user name

                            userName = txt_soVi.Text;
                            if (userName == null || userName.Length <= 0)
                            {
                                String s = "";
                                FSDK.SetName(tracker, IDs[i], "");
                                FSDK.PurgeID(tracker, IDs[i]);
                            }
                            else
                            {
                                FSDK.SetName(tracker, IDs[i], userName);
                            }
                            FSDK.UnlockID(tracker, IDs[i]);



                        }
                        lb_ketQuaDangKiKhuonMat.Text = "Đăng kí khuôn mặt thành công" +
                            "\r\nCho số ví: " + userName;
                        if (FSDK.SaveTrackerMemoryToFile(tracker, fileName) == FSDK.FSDKE_OK)
                        {
                            MessageBox.Show("OK");
                        }

                //batDauDangKi = false;
            }

                    gr.DrawRectangle(pen, left, top, w, w);


                }
                //programState = ProgramState.psRecognize;

                // Hiển thị khung hiện tại
                pictureBox1.Image = frameImage;
                GC.Collect(); // Thu gom rác sau khi xóa 
            }
            FSDK.SaveTrackerMemoryToFile(tracker, TrackerMemoryFile);
            FSDK.FreeTracker(tracker);

            FSDKCam.CloseVideoCamera(cameraHandle);
            FSDKCam.FinalizeCapturing();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            programState = ProgramState.psRemember;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            mouseX = 0;
            mouseY = 0;
        }

        private void btn_dangKiKhuonMat_Click(object sender, EventArgs e)
        {
            batDauDangKi = true;
            programState = ProgramState.psRemember;
        }
    }

}

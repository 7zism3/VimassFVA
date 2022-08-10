using Luxand;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        static string path = "C:\\Users\\welcome\\Documents\\Vimass\\dataFAV.txt";
        static string pathSoVi = "C:\\Users\\welcome\\Documents\\Vimass\\dataViFAV.txt";

        bool needClose = false;
        String cameraName;

        FSDK.TFacePosition facePosition_Global;
        bool isLiveness = false;
        byte[] template_Global;
        int image_Global;
        static byte[] template_FromFile;
        static String soVi_FromFile;
        static String soVi;
        static bool daDocThongTinTuFile = false;

        int soLanXacThuc;

        public Main()
        {
            InitializeComponent();

        }

        private void Main_Load(object sender, EventArgs e)
        {
            String keyLX = "uypkToItYK8NviZCLG+n9L6lgekJ5n5TWWkroruVGQf+Ku3pl30qunu" +
                "TAYchwRC2MLKLubUspp+QI4BTUNHnCSiZbEcHmoOmxE4e/HTHik6bxM7I5V9LnggPE" +
                "yDw8ga1Q4IfbBE5aR4mc9RgKRz6e9y/99phHELlXK03W1zur6w=";
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
            int VideoFormat = 0; // Chọn một định dạng video
            pictureBox1.Width = formatList[VideoFormat].Width;
            pictureBox1.Height = formatList[VideoFormat].Height;
            lb_thongBao.Text = "";
        }

        private void LoadDataFromFile()
        {
            try
            {
                template_FromFile = File.ReadAllBytes(path);
                soVi_FromFile = File.ReadAllText(pathSoVi);
                if (soVi_FromFile.CompareTo(soVi) == 0) 
                {
                    if (template_FromFile == null || template_FromFile == new byte[FSDK.TemplateSize])
                    {
                        btn_dangKy.Enabled = true;
                        btn_xacThuc.Enabled = false;
                        daDocThongTinTuFile = false;
                        lb_thongBao.Text = "\"Số ví không có dữ liệu khuôn mặt\nVui lòng đăng ký thông tin\"";
                        lb_thongBao.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        btn_dangKy.Enabled = false;
                        btn_xacThuc.Enabled = true;
                        daDocThongTinTuFile = true;
                        lb_thongBao.Text = "\"Đã có dữ liệu khuôn mặt\nVui lòng xác thực\"";
                        lb_thongBao.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                    }
                } 
                else
                {
                    btn_dangKy.Enabled = true;
                    btn_xacThuc.Enabled = false;
                    lb_thongBao.Text = "\"Số ví không có dữ liệu khuôn mặt\nVui lòng đăng ký thông tin\"";
                    lb_thongBao.ForeColor = System.Drawing.Color.Red;
                }
                
            }
            catch (Exception e)
            {
                btn_dangKy.Enabled = true;
                btn_xacThuc.Enabled = false;
                daDocThongTinTuFile = false;
                lb_thongBao.Text = "\"Số ví không có dữ liệu khuôn mặt\nVui lòng đăng ký thông tin\"";
                lb_thongBao.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btn_khoiDongCamera_Click(object sender, EventArgs e)
        {
            soVi = txt_soVi.Text;
            LoadDataFromFile();
            khoiDongCamera();
        }

        private void khoiDongCamera()
        {
            //
            this.btn_khoiDongCamera.Enabled = false;
            int cameraHandle = 0;

            int r = FSDKCam.OpenVideoCamera(ref cameraName, ref cameraHandle);
            if (r != FSDK.FSDKE_OK)
            {
                MessageBox.Show("Lỗi mở camera thứ 1", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            int tracker = 0; 	// creating a Tracker
            FSDK.CreateTracker(ref tracker); // if could not be loaded, create a new tracker

            int err = 0; // set realtime face detection parameters
            FSDK.SetTrackerMultipleParameters(tracker, "HandleArbitraryRotations=false; DetermineFaceRotationAngle=false; InternalResizeWidth=100; FaceDetectionThreshold=5;", ref err);
            FSDK.SetTrackerParameter(tracker, "DetectLiveness", "true"); // enable liveness
            FSDK.SetTrackerParameter(tracker, "SmoothAttributeLiveness", "true"); // use smooth minimum function for liveness values
            FSDK.SetTrackerParameter(tracker, "AttributeLivenessSmoothingAlpha", "1"); // smooth minimum parameter, 0 -> mean, inf -> min
            FSDK.SetTrackerParameter(tracker, "LivenessFramesCount", "15"); // minimal number of frames required to output liveness attribute

            while (!needClose)
            {
                Int32 imageHandle = 0;
                if (FSDK.FSDKE_OK != FSDKCam.GrabFrame(cameraHandle, ref imageHandle)) // grab the current frame from the camera
                {
                    Application.DoEvents();
                    continue;
                }
                FSDK.CImage image_Global = new FSDK.CImage(imageHandle);

                long[] IDs;
                long faceCount = 0;
                FSDK.FeedFrame(tracker, 0, image_Global.ImageHandle, ref faceCount, out IDs, sizeof(long) * 256); // maximum of 256 faces detected
                Array.Resize(ref IDs, (int)faceCount);

                // make UI controls accessible (to find if the user clicked on a face)
                Application.DoEvents();

                Image frameImage = image_Global.ToCLRImage();
                Graphics gr = Graphics.FromImage(frameImage);

                for (int i = 0; i < IDs.Length; ++i)
                {
                    FSDK.TFacePosition facePosition = new FSDK.TFacePosition();
                    FSDK.GetTrackerFacePosition(tracker, 0, IDs[i], ref facePosition);

                    int left = facePosition.xc - (int)(facePosition.w * 0.6);
                    int top = facePosition.yc - (int)(facePosition.w * 0.5);
                    int w = (int)(facePosition.w * 1.2);

                    String statusText;
                    StringFormat format = new StringFormat();
                    format.Alignment = StringAlignment.Center;
                    Brush brush;
                    Pen pen;
                    string value;
                    float liveness = 0;

                    int res = FSDK.GetTrackerFacialAttribute(tracker, cameraHandle, IDs[i], "Liveness", out value, 1024);
                    if (res == FSDK.FSDKE_OK)
                    {
                        res = FSDK.GetValueConfidence(value, "Liveness", ref liveness);
                    }

                    if (res != FSDK.FSDKE_OK)
                    {
                        pen = Pens.LightGreen;
                        brush = new System.Drawing.SolidBrush(System.Drawing.Color.LightGreen);
                        statusText = "";
                    }
                    else if (liveness > 0.5f)
                    {
                        isLiveness = true;
                        pen = Pens.LightGreen;
                        brush = new System.Drawing.SolidBrush(System.Drawing.Color.LightGreen);
                        statusText = "\"Vui lòng lựa chọn hành động\"";
                    }
                    else
                    {
                        pen = Pens.Red;
                        brush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
                        statusText = "\"Đây không phải người thật\"";
                    }

                    gr.DrawString(statusText, new System.Drawing.Font("Arial", 16),
                        brush, facePosition.xc, top + w + 5, format);
                    gr.DrawRectangle(pen, left, top, w, w);
                }
                /*if (soLanXacThuc < 5)
                {
                    DoSomethingEverySeconds();
                }*/
                // display current frame
                pictureBox1.Image = frameImage;
                GC.Collect(); // collect the garbage after the deletion
            }

            FSDK.FreeTracker(tracker);
            FSDKCam.CloseVideoCamera(cameraHandle);
            FSDKCam.FinalizeCapturing();
        }

        public async Task DoSomethingEverySeconds()
        {
            while (true)
            {
                var delayTask = Task.Delay(5000);
                //DoSomething();
                await delayTask; // wait until at least 10s elapsed since delayTask created
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            programState = ProgramState.psRemember;
        }

        private void btn_dangKiKhuonMat_Click(object sender, EventArgs e)
        {
            dangKy();
        }

        private void dangKy()
        {
            int res2 = FSDK.DetectFace(image_Global, ref facePosition_Global);
            if (res2 == FSDK.FSDKE_FACE_NOT_FOUND)
            {
                lb_thongBao.Text = "\"Không tìm thấy khuôn mặt\"";
                lb_thongBao.ForeColor = System.Drawing.Color.Red;
            }
            else if (res2 == FSDK.FSDKE_IMAGE_TOO_SMALL)
            {
                lb_thongBao.Text = "\"Vui lòng di chuyển gần camera hơn\"";
                lb_thongBao.ForeColor = System.Drawing.Color.Red;
            }
            else if (res2 == FSDK.FSDKE_OK)
            {
                if (isLiveness)
                {
                    template_Global = new byte[FSDK.TemplateSize];
                    FSDK.GetFaceTemplate(image_Global, out template_Global);
                    try
                    {
                        File.WriteAllBytes(path, template_Global);
                        File.WriteAllText(pathSoVi, soVi);
                        lb_thongBao.Text = "\"Đăng kí khuôn mặt thành công" +
                              "\r\nCho số ví: " + soVi + "\"";
                        lb_thongBao.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                        MessageBox.Show("Đã lưu thông tin templace", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_xacThuc.Enabled = true;
                        btn_dangKy.Enabled = false;
                    }
                    catch (Exception)
                    {
                        lb_thongBao.Text = "\"Đăng kí khuôn mặt không thành công thành công" +
                              "\r\nLỗi khi lưu thông tin\"";
                        lb_thongBao.ForeColor = System.Drawing.Color.Red;

                    }
                }
            }
        }

        private void btn_xacThuc_Click(object sender, EventArgs e)
        {
            xacThuc();
        }
        private void xacThuc()
        {
            if (soLanXacThuc < 3)
            {
                int res2 = FSDK.DetectFace(image_Global, ref facePosition_Global);
                if (res2 == FSDK.FSDKE_FACE_NOT_FOUND)
                {
                    lb_thongBao.Text = "\"Không tìm thấy khuôn mặt\"";
                    lb_thongBao.ForeColor = System.Drawing.Color.Red;
                }
                else if (res2 == FSDK.FSDKE_IMAGE_TOO_SMALL)
                {
                    lb_thongBao.Text = "\"Vui lòng di chuyển gần camera hơn\"";
                    lb_thongBao.ForeColor = System.Drawing.Color.Red;
                }
                else if (res2 == FSDK.FSDKE_OK)
                {
                    if (isLiveness)
                    {
                        template_Global = new byte[FSDK.TemplateSize];
                        FSDK.GetFaceTemplate(image_Global, out template_Global);
                        if (daDocThongTinTuFile)
                        {
                            float matchingThreshold = 0;
                            float similarity = 0;
                            FSDK.GetMatchingThresholdAtFAR((float)0.02, ref matchingThreshold);
                            FSDK.MatchFaces(ref template_Global, ref template_FromFile, ref similarity);
                            if (similarity > matchingThreshold)
                            {
                                lb_thongBao.Text = "\"Xác thực khuôn mặt thành công!\"";
                                lb_thongBao.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                                // Lưu dữ liệu khuôn mặt mới vào file
                                File.WriteAllBytes(path, template_Global);
                                File.WriteAllText(pathSoVi, soVi);
                            }
                            else
                            {
                                soLanXacThuc++;
                                lb_thongBao.Text = "\"Xác thực khuôn mặt thất bại, lần " + soLanXacThuc +"\"";
                                lb_thongBao.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                    }
                } 
            }
            else
            {
                lb_thongBao.Text = "\"Bạn đã xác thực quá 3 lần, Vui lòng thử lại sau\"";
                lb_thongBao.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}

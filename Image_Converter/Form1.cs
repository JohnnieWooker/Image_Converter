using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace Image_Converter
{

    
    


    public partial class Form1 : Form
    {

        List<string> destpaths = new List<string>();
        List<string> sourcepaths = new List<string>();

        long quality = 80;

        public Form1()
        {
            
            InitializeComponent();
            textBox_quality.Text = quality.ToString();
            this.AllowDrop = true;
            //this.listView1.DragEnter += new DragEventHandler(this.listView1_DragEnter);
           // this.listView1.DragDrop += new DragEventHandler(this.listView1_DragDrop);
            this.textBox2.DragEnter += new DragEventHandler(this.textBox2_DragEnter);
            this.textBox2.DragDrop += new DragEventHandler(this.textBox2_DragDrop);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                quality = Convert.ToInt64(textBox_quality.Text);
                button1.Enabled = false;
                if (radioButton2.Checked)
                {

                    var allfiles = Directory.GetFiles(textBox1.Text, "*.*", SearchOption.AllDirectories)
                        .Where(s => s.EndsWith(".tga", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".png", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".tga", StringComparison.OrdinalIgnoreCase)); ;
                    foreach (var file in allfiles)
                    {
                        FileInfo info = new FileInfo(file);
                        // MessageBox.Show(file.ToString());

                        ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
                        var encoder = System.Drawing.Imaging.Encoder.Quality;
                        var encoderParameters = new EncoderParameters(1);
                        var encoderParameter = new EncoderParameter(encoder, quality);
                        encoderParameters.Param[0] = encoderParameter;


                        string filename = file.ToString();
                        string newFilename = filename.Substring(0, filename.LastIndexOf(".")) + ".jpg";
                        Image img = Image.FromFile(filename);
                        img.Save(newFilename, jgpEncoder, encoderParameters);


                        // Do something with the Folder or just add them to a list via nameoflist.add();
                    }
                }
                else
                {

                    ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
                    var encoder = System.Drawing.Imaging.Encoder.Quality;
                    var encoderParameters = new EncoderParameters(1);
                    var encoderParameter = new EncoderParameter(encoder, quality);
                    encoderParameters.Param[0] = encoderParameter;




                    string filename = textBox1.Text;
                    string newFilename = filename.Substring(0, filename.LastIndexOf(".")) + ".jpg";
                    Image img = Image.FromFile(filename);
                    /*
                    using (var b = new Bitmap(img.Width, img.Height))
                    {
                        b.SetResolution(img.HorizontalResolution, img.VerticalResolution);

                        using (var g = Graphics.FromImage(b))
                        {
                            g.Clear(Color.White);
                            g.DrawImageUnscaled(img, 0, 0);
                        }

                        // Now save b as a JPEG like you normally would
                    }
                    */
                    img.Save(newFilename, jgpEncoder, encoderParameters);
                    if (new FileInfo(newFilename).Length > new FileInfo(filename).Length)
                    {
                        //MessageBox.Show("jpg is bigger");
                        File.Delete(newFilename);
                        //File.WriteAllText(yourFilePath, String.Empty);
                    }
                    else
                    {
                        
                        //MessageBox.Show("png is bigger");
                    }
                }
                button1.Enabled = true;
            }

            else
            {
                quality = Convert.ToInt64(textBox_quality.Text);
                button1.Enabled = false;
                if (radioButton2.Checked)
                {

                    var allfiles = Directory.GetFiles(textBox1.Text, "*.*", SearchOption.AllDirectories)
                        .Where(s => s.EndsWith(".tga", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".png", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".tga", StringComparison.OrdinalIgnoreCase)); ;
                    foreach (var file in allfiles)
                    {
                        FileInfo info = new FileInfo(file);
                        // MessageBox.Show(file.ToString());

                        ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
                        var encoder = System.Drawing.Imaging.Encoder.Quality;
                        var encoderParameters = new EncoderParameters(1);
                        var encoderParameter = new EncoderParameter(encoder, quality);
                        encoderParameters.Param[0] = encoderParameter;


                        string filename = file.ToString();
                        string newFilename = filename.Substring(0, filename.LastIndexOf(".")) + ".jpg";
                        Image img = Image.FromFile(filename);
                        img.Save(newFilename, jgpEncoder, encoderParameters);


                        // Do something with the Folder or just add them to a list via nameoflist.add();
                    }
                }
                else
                {

                    ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
                    var encoder = System.Drawing.Imaging.Encoder.Quality;
                    var encoderParameters = new EncoderParameters(1);
                    var encoderParameter = new EncoderParameter(encoder, quality);
                    encoderParameters.Param[0] = encoderParameter;




                    string filename = textBox1.Text;
                    string newFilename = filename.Substring(0, filename.LastIndexOf(".")) + ".jpg";
                    Image img = Image.FromFile(filename);
                    /*
                    using (var b = new Bitmap(img.Width, img.Height))
                    {
                        b.SetResolution(img.HorizontalResolution, img.VerticalResolution);

                        using (var g = Graphics.FromImage(b))
                        {
                            g.Clear(Color.White);
                            g.DrawImageUnscaled(img, 0, 0);
                        }

                        // Now save b as a JPEG like you normally would
                    }
                    */
                    img.Save(newFilename, jgpEncoder, encoderParameters);

                }
                button1.Enabled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            transferalpha(textBox2.Text, textBox3.Text,false,0);

        }
        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }


        void Form_DragDrop(object sender, DragEventArgs e)
        {

            
            //more processing
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            //MessageBox.Show(FileList[0]);
        }

        private void textBox2_DragDrop(object sender, DragEventArgs e)
        {
            textBox2.Text = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
        }

        private void textBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;                      
        }                                                 
                                                             
        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            string[] path = ((string[])e.Data.GetData(DataFormats.FileDrop));

            foreach (string s in path)
            {
                sourcepaths.Add(s);
                string temp = s;
                try
                {
                    temp = temp.Substring(temp.LastIndexOf("\\") + 1);
                }
                catch
                { }
                 listView1.Items.Add(temp);
            }
        }

        private void listView2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void listView2_DragDrop(object sender, DragEventArgs e)
        {
            string[] path = ((string[])e.Data.GetData(DataFormats.FileDrop));

            foreach (string s in path)
            {
                destpaths.Add(s);
                string temp = s;
                try
                {
                    temp = temp.Substring(temp.LastIndexOf("\\") + 1);
                }
                catch
                { }
                listView2.Items.Add(temp);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(sourcepaths.Count() + "\r\n" + destpaths.Count());
            //int counter = 0;           
/*
            string msg = "";
            foreach (string s in sourcepaths)
            {
                msg += s;
            }
            MessageBox.Show(msg);
            */
            button3.Enabled = false;
             backgroundWorker1.RunWorkerAsync();



        }

        void transferalpha(string source, string destination,bool islist, int counter)
        {
            bool alphegrey = checkBox2.Checked;
            ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
            var encoder = System.Drawing.Imaging.Encoder.Quality;
            var encoderParameters = new EncoderParameters(1);
            var encoderParameter = new EncoderParameter(encoder, 100L);
            encoderParameters.Param[0] = encoderParameter;


            string imagePath = source;
            Bitmap bitmap_sources = new Bitmap(imagePath);
            var rect = new Rectangle(0, 0, bitmap_sources.Width, bitmap_sources.Height);
            BitmapData bmData = bitmap_sources.LockBits(rect, ImageLockMode.ReadOnly, bitmap_sources.PixelFormat);


            //Bitmap alphaBitmap_dest = new Bitmap();
            //  Bitmap clone = new Bitmap(orig.Width, orig.Height,
            // System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

            Bitmap orig = new Bitmap(destination);
            Bitmap alphaBitmap = new Bitmap(orig.Width, orig.Height, PixelFormat.Format32bppPArgb);

            using (Graphics gr = Graphics.FromImage(alphaBitmap))
            {
                gr.DrawImage(orig, new Rectangle(0, 0, alphaBitmap.Width, alphaBitmap.Height));
            }


            // var alphaBitmap = new Bitmap(bmData.Width, bmData.Height, PixelFormat.Format32bppArgb);

            for (int y = 0; y <= bmData.Height - 1; y++)
            {
                for (int x = 0; x <= bmData.Width - 1; x++)
                {
                    Color PixelColor = Color.FromArgb(Marshal.ReadInt32(bmData.Scan0, (bmData.Stride * y) + (4 * x)));
                    if (PixelColor.A > 0 & PixelColor.A <= 255)
                    {
                        Color old = alphaBitmap.GetPixel(x, y);
                       if (alphegrey) alphaBitmap.SetPixel(x, y, Color.FromArgb(PixelColor.R, old.R, old.G, old.B));
                        else alphaBitmap.SetPixel(x, y, Color.FromArgb(PixelColor.A, old.R, old.G, old.B));
                    }
                    else
                    {
                        Color old = alphaBitmap.GetPixel(x, y);
                       if (alphegrey) alphaBitmap.SetPixel(x, y, Color.FromArgb(PixelColor.R, old.R, old.G, old.B));
                       else alphaBitmap.SetPixel(x, y, Color.FromArgb(0, old.R, old.G, old.B));
                    }
                }
            }
            bitmap_sources.UnlockBits(bmData);
            orig.Dispose();
            orig.Dispose();
            bitmap_sources.Dispose();


            string destpath = destination;
            destpath = destpath.Substring(0, destpath.LastIndexOf(".")) + ".png";
            alphaBitmap.Save(destpath, ImageFormat.Png);

            if (islist)
            {
                try
                {
                    //MessageBox.Show("try to change");
                    
                }
                catch{ }

            }


        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
            int counter = 0;
            
            foreach (string s in sourcepaths)
            {
                transferalpha(s, destpaths[counter], true, counter);
                AppendColor(counter);
                counter++;
            }



            /*
            List<Task> tasks = new List<Task>();
            for (int i = -1; i < sourcepaths.Count() - 1; i++)
            {
               // MessageBox.Show(i.ToString());
                var LastTask = new Task(() => transferalpha(sourcepaths[i], destpaths[i], true, i));
                LastTask.Start();
                tasks.Add(LastTask);
                //Task task = Task.Factory.StartNew(() => transferalpha(s,destpaths[counter],true,counter));
                //tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());


    */
        }

        public void AppendColor(int i)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(AppendColor), new object[] { i });
                return;
            }
            listView1.Items[i].ForeColor = Color.Green;
            listView2.Items[i].ForeColor = Color.Green;
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {

           


            string path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            sourcepaths.Add(path);
            try
            {
                if (radioButton1.Checked) textBox1.Text = path;
                else
                {
                    FileAttributes attr = File.GetAttributes(path);

                    //detect whether its a directory or file
                    if ((attr & FileAttributes.Directory) == FileAttributes.Directory) textBox1.Text = path;
                    else textBox1.Text = path.Substring(0, path.LastIndexOf("\\")) + "\\";

                }
            }
            catch
            { }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                string path = textBox1.Text;
                FileAttributes attr = File.GetAttributes(path);
                //detect whether its a directory or file
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory) textBox1.Text = path;
                else textBox1.Text = path.Substring(0, path.LastIndexOf("\\")) + "\\";
                /*
                char last = textBox1.Text[textBox1.Text.Length - 1];
                if (!last.Equals("\\"))
                {
                    string temp = textBox1.Text;
                    temp = temp.Substring(0, temp.LastIndexOf("\\")) + "\\";
                    textBox1.Text = temp;
                }
                */
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button3.Enabled = true;
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Delete == e.KeyCode)
            {
                foreach (ListViewItem listViewItem in ((ListView)sender).SelectedItems)
                {
                    sourcepaths.RemoveAt(listViewItem.Index);
                    listViewItem.Remove();
                }
            }
        }

        private void listView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Delete == e.KeyCode)
            {
                foreach (ListViewItem listViewItem in ((ListView)sender).SelectedItems)
                {
                  destpaths.RemoveAt(listViewItem.Index);
                  listViewItem.Remove();
                }
            }
        }

        private void textBox_quality_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox_quality.Text, out parsedValue))
            {
                textBox_quality.Text = "80";
            }
            else
            {
                if (Convert.ToInt64(textBox_quality.Text) > 100) textBox_quality.Text = "100";
                if (Convert.ToInt64(textBox_quality.Text) < 0) textBox_quality.Text = "0";

            }
            
          
         }
    }


}

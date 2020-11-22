using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Work_with_API.Helper;

namespace Work_with_API
{
    public class ApiVM : INotifyPropertyChanged
    {
        private Student selectedStudent;
        private BitmapImage studentImage;
        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();
        public ApiVM()
        {
            MakeRequestStudents();
        }
     
        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                SetPhoto();
                OnNotify();
            }
        }
        public BitmapImage StudentImage
        {
            get => studentImage;
            set
            {
                studentImage = value;
                OnNotify();
            }
        }

        public async void SetPhoto()
        {
            var byteArray = await RequestHelper.GetPhoto(SelectedStudent);

            MemoryStream memorystream = new MemoryStream();
            memorystream.Write(byteArray, 0, byteArray.Length);

            BitmapImage imgsource = new BitmapImage();
            memorystream.Write(byteArray, 0, byteArray.Length);
            memorystream.Seek(0, SeekOrigin.Begin);
            imgsource.BeginInit();
            imgsource.StreamSource = memorystream;
            imgsource.EndInit();
            StudentImage = imgsource;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnNotify([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public async void MakeRequestStudents()
        {
            List<Student> temp = await RequestHelper.GetStudents();
            Students.Clear();
            foreach (var item in temp)
            {
                Students.Add(item);
            }
        }       
    }
}

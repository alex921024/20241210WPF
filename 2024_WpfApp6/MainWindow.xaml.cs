using System.Windows;

namespace _2024_WpfApp6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // 建立學生、教師、課程和紀錄的列表
        List<Student> students = new List<Student>();
        List<Teacher> teachers = new List<Teacher>();
        List<Course> courses = new List<Course>();
        List<Record> records = new List<Record>();

        // 建立所選擇的學生、教師、課程和紀錄的變數
        Student selectedStudent = null;
        Teacher selectedTeacher = null;
        Course selectedCourse = null;
        Record selectedRecord = null;

        public MainWindow()
        {
            InitializeComponent();
            InitailizeData(); // 初始化數據
        }

        private void InitailizeData()
        {
            // 新增學生資料，連結至cmbStudent
            students.Add(new Student { StudentId = "4b2g0912", StudentName = "楊晋峰" }); // 新增學生"楊晋峰"
            students.Add(new Student { StudentId = "4b2g0002", StudentName = "華" }); // 新增學生"華"
            students.Add(new Student { StudentId = "4b2g0012", StudentName = "英" }); // 新增學生"英"
            cmbStudent.ItemsSource = students; // 設定cmbStudent的項目來源為students列表
            cmbStudent.SelectedIndex = 0; // 預設選擇第一個學生

            // 新增教師資料以及所授課程
            Teacher teacher1 = new Teacher("陳定宏"); // 新增教師"陳定宏"
            teacher1.TeachingCourses.Add(new Course { CourseName = "視窗程式設計", OpeningClass = "四技資工二甲", Point = 3, Tutor = teacher1, Type = "選修" }); // 新增課程"視窗程式設計"
            teacher1.TeachingCourses.Add(new Course { CourseName = "視窗程式設計", OpeningClass = "五專資工三甲", Point = 3, Tutor = teacher1, Type = "選修" }); // 新增課程"視窗程式設計"
            teacher1.TeachingCourses.Add(new Course { CourseName = "資料庫系統", OpeningClass = "四技資工二乙", Point = 3, Tutor = teacher1, Type = "必修" }); // 新增課程"資料庫系統"
            teachers.Add(teacher1); // 將teacher1加入teachers列表

            Teacher teacher2 = new Teacher("林志玲"); // 新增教師"林志玲"
            teacher2.TeachingCourses.Add(new Course { CourseName = "資料結構", OpeningClass = "四技資工二甲", Point = 3, Tutor = teacher2, Type = "必修" }); // 新增課程"資料結構"
            teacher2.TeachingCourses.Add(new Course { CourseName = "作業系統", OpeningClass = "四技資工二甲", Point = 3, Tutor = teacher2, Type = "必修" }); // 新增課程"作業系統"
            teacher2.TeachingCourses.Add(new Course { CourseName = "網路程式設計", OpeningClass = "四技資工二乙", Point = 3, Tutor = teacher2, Type = "選修" }); // 新增課程"網路程式設計"
            teachers.Add(teacher2); // 將teacher2加入teachers列表

            Teacher teacher3 = new Teacher("張學友"); // 新增教師"張學友"
            teacher3.TeachingCourses.Add(new Course { CourseName = "計算機概論", OpeningClass = "四技資工二甲", Point = 3, Tutor = teacher3, Type = "必修" }); // 新增課程"計算機概論"
            teacher3.TeachingCourses.Add(new Course { CourseName = "組合語言", OpeningClass = "四技資工二甲", Point = 3, Tutor = teacher3, Type = "必修" }); // 新增課程"組合語言"
            teacher3.TeachingCourses.Add(new Course { CourseName = "資訊安全", OpeningClass = "四技資工二乙", Point = 3, Tutor = teacher3, Type = "選修" }); // 新增課程"資訊安全"
            teachers.Add(teacher3); // 將teacher3加入teachers列表

            // 新增更多教師和課程
            Teacher teacher4 = new Teacher("鄭秀文"); // 新增教師"鄭秀文"
            teacher4.TeachingCourses.Add(new Course { CourseName = "人工智慧", OpeningClass = "四技資工三甲", Point = 3, Tutor = teacher4, Type = "選修" }); // 新增課程"人工智慧"
            teacher4.TeachingCourses.Add(new Course { CourseName = "機器學習", OpeningClass = "四技資工三乙", Point = 3, Tutor = teacher4, Type = "選修" }); // 新增課程"機器學習"
            teacher4.TeachingCourses.Add(new Course { CourseName = "自然語言處理", OpeningClass = "五專資工五甲", Point = 3, Tutor = teacher4, Type = "選修" }); // 新增課程"自然語言處理"
            teachers.Add(teacher4); // 將teacher4加入teachers列表

            Teacher teacher5 = new Teacher("周杰倫"); // 新增教師"周杰倫"
            teacher5.TeachingCourses.Add(new Course { CourseName = "音樂與程式設計", OpeningClass = "四技資工三乙", Point = 3, Tutor = teacher5, Type = "選修" }); // 新增課程"音樂與程式設計"
            teacher5.TeachingCourses.Add(new Course { CourseName = "多媒體系統", OpeningClass = "五專資工五甲", Point = 3, Tutor = teacher5, Type = "選修" }); // 新增課程"多媒體系統"
            teacher5.TeachingCourses.Add(new Course { CourseName = "遊戲開發", OpeningClass = "四技資工三甲", Point = 3, Tutor = teacher5, Type = "選修" }); // 新增課程"遊戲開發"
            teachers.Add(teacher5); // 將teacher5加入teachers列表

            tvTeacher.ItemsSource = teachers; // 設定tvTeacher的項目來源為teachers列表

            foreach (Teacher teacher in teachers)
            {
                foreach (Course course in teacher.TeachingCourses)
                {
                    courses.Add(course); // 將每個教師的課程加入courses列表
                }
            }

            lbCourse.ItemsSource = courses; // 設定lbCourse的項目來源為courses列表
        }

        private void tvTeacher_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (tvTeacher.SelectedItem is Teacher)
            {
                selectedTeacher = tvTeacher.SelectedItem as Teacher; // 獲取所選的教師
                statusLabel.Content = $"選取老師:{selectedTeacher.TeacherName}"; // 顯示所選教師的名字
            }
            if (tvTeacher.SelectedItem is Course)
            {
                selectedCourse = tvTeacher.SelectedItem as Course; // 獲取所選的課程
                statusLabel.Content = $"選取課程:{selectedCourse.CourseName}"; // 顯示所選課程的名字
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (selectedStudent == null || selectedCourse == null)
            {
                MessageBox.Show("請選取學生或課程"); // 提示用戶選取學生或課程
                return;
            }
            else
            {
                Record record = new Record()
                {
                    SelectedStudent = selectedStudent, // 設定所選學生
                    SelectedCourse = selectedCourse // 設定所選課程
                };

                foreach (Record r in records)
                {
                    if (r.Equals(record))
                    {
                        MessageBox.Show("此學生已選取此課程"); // 提示用戶此學生已選取該課程
                        return;
                    }
                }

                records.Add(record); // 新增紀錄至records列表
                lvRecord.ItemsSource = records; // 更新lvRecord的項目來源
                lvRecord.Items.Refresh(); // 刷新lvRecord顯示
            }
        }

        private void cmbStudent_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedStudent = cmbStudent.SelectedItem as Student; // 獲取所選的學生
            statusLabel.Content = $"選取學生:{selectedStudent.StudentName}"; // 顯示所選學生的名字
        }

        private void lbCourse_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedCourse = lbCourse.SelectedItem as Course; // 獲取所選的課程
            statusLabel.Content = $"選取課程:{selectedCourse.CourseName}"; // 顯示所選課程的名字
        }
    }

}
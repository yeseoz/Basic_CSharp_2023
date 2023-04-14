using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace wf14_winforms_thread
{
    public partial class FrmMain : Form
    {
        int number = 0;
        int percent = 0;

        public FrmMain()
        {
            InitializeComponent();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            Worker.WorkerSupportsCancellation = true;
            Worker.WorkerReportsProgress = true;
        }

        // 백그라운드로 일 진행 // Thread..Start();
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker; // 인자값으로 BackgroundWorker 생성

            e.Result = Fibonacci((int)e.Argument, worker, e); // 피보나치 계산하는 메서드
        }

        private long Fibonacci(int argument, BackgroundWorker worker, DoWorkEventArgs e)
        {
            //arg는 0~91사이 
            if(argument<0|| argument>91)
            {
                throw new Exception("오류 0~91 사이 입력");
            }
            long result = 0;

            if (worker.CancellationPending == true)
            {
                e.Cancel = true;
            }
            else
            {
                if (argument < 2)
                {
                    result = 1;
                }
                else
                {
                    //argment만 계산에 필요한 매개변수, worker, e 중간에 취소할때 필요한 Backworker 복사본
                    result = Fibonacci(argument - 1, worker, e) + Fibonacci(argument - 2, worker, e);
                }

                // 진행사항을 프로그래스바에 표시
                int percentComplete = (int)(argument / number * 100);
                if (percentComplete > percent)
                {
                    percent = percentComplete;
                    worker.ReportProgress(percentComplete); // ProgressChanged 이벤트 발생
                }
            }
            return result;
        }

        // 백그라운드 스레드 태스크 종료한 뒤 처리
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            PgbCalculate.Value = e.ProgressPercentage; // 진행사항 표시
        }

        // 백그라운드 스레드 진행중 프로그래스 
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                LblResult.Text = "취소됨";
            }
            else
            {
                LblResult.Text = e.Result.ToString();
            }

            TxtNumber.Text = 0.ToString();
            BtnStart.Enabled = true;
            BtnCancel.Enabled = false; ;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            BtnStart.Enabled = false; // 종료시까지 누르지 못하게
            BtnCancel.Enabled = true;

            number = int.Parse(TxtNumber.Text); // 정수로 표현

            percent = 0;
            PgbCalculate.Value = percent;
            Worker.RunWorkerAsync(number); // 비동기로 진행
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Worker.CancelAsync(); // 비동기로 취소시키라고 요청
            BtnCancel.Enabled = false;
            BtnStart.Enabled=true;
        }

        private void TxtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==13)
            {
                BtnStart_Click(sender, e);
            }
        }
    }
}

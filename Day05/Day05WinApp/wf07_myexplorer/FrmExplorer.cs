﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace wf07_myexplorer
{
    public partial class FrmExplorer : Form
    {
        public FrmExplorer()
        {
            InitializeComponent();
        }

        private void FrmExplorer_Load(object sender, EventArgs e)
        {
            //현재 사용자 출력
            WindowsIdentity identity = WindowsIdentity.GetCurrent(); // 현재 Windows 사용자를 나타내는 WindowsIdentity 개체를 반환
            LblPath.Text = identity.Name; // 사용자의 Windows 로그온 이름을 가져옴

            // 현재 컴퓨터에 존재하는 드라이브 정보검색, 트리뷰 추가
            DriveInfo[] drives = DriveInfo.GetDrives();

            // 트리뷰에 전부 추가
            foreach (DriveInfo drive in drives)
            {
                if (drive.DriveType == DriveType.Fixed) // 드라이브가 고정디스크라면(SSD/HDD)
                {
                    TreeNode rootNode = new TreeNode(drive.Name); // C, D 드라이브의 이름을 가지는 TreeNode
                    rootNode.ImageIndex = 0; // 평소 이미지는 0번
                    rootNode.SelectedImageIndex = 0; // 선택된 이미지도 0번
                    TrvDrive.Nodes.Add(rootNode); // TrvDrive에 노드 추가함
                    FillNodes(rootNode);
                }
            }

            TrvDrive.Nodes[0].Expand();

            // 리스트뷰 설정
            LsvFolder.View = View.Details; // View를 Details로 설정

            LsvFolder.Columns.Add("이름", LsvFolder.Width / 2, HorizontalAlignment.Left); // dir.name, file.name
            LsvFolder.Columns.Add("날짜", LsvFolder.Width / 4, HorizontalAlignment.Left);
            LsvFolder.Columns.Add("유형", LsvFolder.Width / 5, HorizontalAlignment.Left);
            LsvFolder.Columns.Add("크기", LsvFolder.Width / 5, HorizontalAlignment.Right);

            //??????
            LsvFolder.FullRowSelect = true; //한행을 전부 선택

        }

        private void FillNodes(TreeNode curNode)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(curNode.FullPath); // 루트 트리노드에서 현재 트리 노드까지의 경로를 가져옴
                // 드라이브 하위폴더
                foreach(DirectoryInfo item in dir.GetDirectories())
                {
                    TreeNode newNode = new TreeNode(item.Name); // DirectoryInfo 인스턴스의 이름을 가져오는 TreeNode
                    newNode.ImageIndex = 1; // 평소에는 1번
                    newNode.SelectedImageIndex = 2; // 선택되면 2번
                    curNode.Nodes.Add(newNode); //현재의 노드에 추가함
                    newNode.Nodes.Add("*");

                }
            }
            catch(Exception)
            {
                MessageBox.Show("오류발생", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // sender는 자기자신에 대한 객체 내용이 들어있고, e에는 이벤트(BeforeExpand)와 관련된 여러가지 속성들이 포함되어있음
        // 마우스 클릭 이벤트라고 쳤을때 e에는 몇번을 눌렀는지 
        /// <summary>
        /// 트리뷰 노드 확장하기 전 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrvDrive_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes[0].Text =="*")
            {
                e.Node.Nodes.Clear();
                e.Node.ImageIndex = 1; // forder-nomal
                e.Node.SelectedImageIndex = 2;
                FillNodes(e.Node); // 하위 폴더를 만들어줌
            }
        }

        /// <summary>
        /// 트리뷰 접기전 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrvDrive_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
                e.Node.ImageIndex = 1;
                e.Node.SelectedImageIndex = 1;
        }
        /// <summary>
        /// 트리노드를 마우스로 클릭했을때의 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void TrvDrive_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SetLsvForder(e.Node.FullPath);
        }

        private void SetLsvForder(string fullPath)
        {
            try
            {
                LsvFolder.Items.Clear(); //기존 리스트 삭제
                DirectoryInfo dir = new DirectoryInfo(fullPath);
                int dirCount = 0;

                foreach(DirectoryInfo item in dir.GetDirectories())
                {
                    ListViewItem lvi = new ListViewItem();

                    lvi.ImageIndex = 1;
                    lvi.Text = item.Name; // 0번 인덱스 => 이름

                    LsvFolder.Items.Add(lvi);
                    LsvFolder.Items[dirCount].SubItems.Add(item.CreationTime.ToString());
                    LsvFolder.Items[dirCount].SubItems.Add("폴더");
                    LsvFolder.Items[dirCount].SubItems.Add(string.Format("{0} files",item.GetFiles().Length.ToString()));

                    dirCount++;
                }// 폴더내 디렉토리 리스트뷰에 리스트업

                // 파일목록 리스트업
                FileInfo[] files = dir.GetFiles();
                int fileCount = dirCount; // 이전 카운트가 승계

                foreach (FileInfo file in files)
                {
                    LsvFolder.Items.Add(file.Name);

                    if (file.LastWriteTime != null)
                    {
                        LsvFolder.Items[fileCount].SubItems.Add(file.LastWriteTime.ToString());
                    }
                    else
                    {
                        LsvFolder.Items[fileCount].SubItems.Add(file.CreationTime.ToString());
                    }
                    LsvFolder.Items[fileCount].SubItems.Add(file.Attributes.ToString());
                    LsvFolder.Items[fileCount].SubItems.Add(file.Length.ToString());

                    fileCount++;
                }

            }
            catch(Exception)
            {
                MessageBox.Show("리스트뷰 오류발생", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Structure_Argument
{
    static class Program
    {
        /// <summary>
        /// ���ε{�����D�n�i�J�I�C
        /// ����k�|��l�����ε{������ı�˦��A�]�w��r�e�{�覡�A�ñҰʥD���� (Form1)�C
        /// </summary>
        [STAThread]
        static void Main()
        {
            // �ҥ����ε{������ı�Ƽ˦��A�Ϫ��M����ŦX�ثe Windows �D�D���~�[
            Application.EnableVisualStyles();

            // �]�w���ε{���ϥιw�]����r�e�{�覡�A�T�O��r��ܮĪG�@�P
            Application.SetCompatibleTextRenderingDefault(false);

            // ����D��� (Form1)�A�i�J�T���j��A�}�l���ε{��
            Application.Run(new Form1());
        }
    }
}

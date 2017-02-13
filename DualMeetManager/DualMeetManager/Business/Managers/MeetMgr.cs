using DualMeetManager.Domain;
using DualMeetManager.Service.Saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DualMeetManager.Business.Managers
{
    public class MeetMgr : Manager
    {
        public Meet openMeet(string filePath)
        {
            ISavingSvc saveSvc = (ISavingSvc)GetService(typeof(ISavingSvc).Name);
            Meet meetToOpen = saveSvc.openMeet(filePath);
            if (meetToOpen == null)
            {
                MessageBox.Show("Meet did NOT open correctly!");
            }
            else
            {
                MessageBox.Show("Meet opened correctly!");
            }
            return meetToOpen;
        }

        public bool saveMeet(string filePath, Meet meetToSave)
        {
            ISavingSvc saveSvc = (ISavingSvc)GetService(typeof(ISavingSvc).Name);
            bool didSave = saveSvc.saveMeet(filePath, meetToSave);
            if (!didSave)
            {
                MessageBox.Show("Meet did NOT save!");
                return false;
            }
            else
            {
                MessageBox.Show("Meet saved correctly at: " + filePath);
                return true;
            }
        }
    }
}

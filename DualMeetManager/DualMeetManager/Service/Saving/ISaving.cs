using DualMeetManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Service.Saving
{
    public interface ISaving
    {
        bool saveMeet(string filePath, Meet meetToSave);   
    }
}

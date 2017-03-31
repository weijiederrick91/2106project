using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team11_2106Project.Domain_Model
{
    interface ICandidateProfile
    {
        ICandidateProfile ViewProfile(int id);
        void EditProfile(ICandidateProfile ic);
        IEnumerable<CandidateProfile> ViewAllProfiles(); 
    }
}

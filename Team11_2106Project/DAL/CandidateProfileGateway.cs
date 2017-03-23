using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Team11_2106Project.Models;

namespace Team11_2106Project.DAL
{
    //CandidateProfileGateway implements DataRUGateway while passing in CandidateProfile model objects to run the operations specified in DataRUGateway.
    //It is part of the DataSourceLayer.
    public class CandidateProfileGateway : DataRUGateway<CandidateProfile>
    {
    }
}
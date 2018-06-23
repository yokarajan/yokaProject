using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi_CRUD.Models;

namespace WebApi_CRUD.Repository
{
    public interface ISampleCRUD
    {
        List<Sample>  GetSample();
        Sample GetSampleById(string id);
         void CreateSample(Sample sampleData);
        void UpdateSample(string id,Sample sampleData);
        void DeleteSample(string id);


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi_CRUD.Models;

namespace WebApi_CRUD.Repository
{
    public class SampleCRUD : ISampleCRUD
    {

        List<Sample> sampleList = new List<Sample>()
        {
            new Sample()
            {
                 Id="SampleId1",
                 ApplicationId=1,
                 Amount=10,
                 ClearedDate=DateTime.Now.AddDays(-5),
                  IsCleared=true,
                 PostingDate=DateTime.Now.AddDays(60)

            },
            new Sample()
            {

                 Id="SampleId2",
                 ApplicationId=2,
                 Amount=1000000,
                 ClearedDate=DateTime.Now.AddDays(-5),
                  IsCleared=true,
                 PostingDate=DateTime.Now.AddDays(60)
            }

        };
        public SampleCRUD(List<Sample> samples)
        {
            samples = sampleList;
        }
        /// <summary>
        /// Create new sample data and into the list
        /// </summary>
        /// <param name="sampleData"></param>
        public void CreateSample(Sample sampleData)
        {
            try
            {
                var sampleInList = sampleList?.Find(x => x.Id == sampleData.Id);
                if (sampleInList == null)
                {
                    sampleList.Add(sampleData);
                }
            }
            catch(Exception ex)
            {
                // Here we need log the error properly 
                throw ex;
            }
        }
        /// <summary>
        /// Remove sample data in list
        /// </summary>
        /// <param name="id"></param>
        public void DeleteSample(string id)
        {
            try
            {
                var result = sampleList?.Find(x => x.Id == id);
                if(result!=null)
                {
                    sampleList.Remove(result);
                }
            }
            catch(Exception ex)
            {
                // Here we need log the error properly 
                throw ex;
            }
        }
        /// <summary>
        /// Read all the sample data in memory
        /// </summary>
        /// <returns></returns>
        public List<Sample> GetSample()
        {
            List<Sample> list = new List<Sample>();
            try
            {
                list = sampleList??null;
            }
            catch(Exception ex)
            {
                // Here we need log the error properly 
                throw ex;
            }
            return list;
        }
        /// <summary>
        /// Get Sample data by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Sample GetSampleById(string id)
        {
            try
            {
                var resultSample = sampleList?.SingleOrDefault(x => x.Id == id);
                return resultSample;
            }
            catch(Exception ex)
            {
                // Here we need log the error properly 
                throw ex;
            }
        }
        /// <summary>
        /// Update the sample data by using given sample data 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sampleData"></param>
        public void UpdateSample(string id,Sample sampleData)
        {
            try
            {
                var sampleInList = sampleList?.Find(x => x.Id == id);

                if (sampleInList!=null)
                {
                    sampleInList.Summery = sampleData.Summery;
                    sampleInList.Type = "Credit";
                }
                
            }
            catch (Exception ex)
            {
                // Here we need log the error properly 
                throw ex;
            }

        }
    }
}
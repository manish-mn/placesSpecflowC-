using NUnit.Framework;
using Places.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Places.Steptransformations
{
    [Binding]
    class Stepargumenttransformation
    {
        [StepArgumentTransformation]
        public Createplace thePlaceDetails(Table table)
        {
            Createplace createplace = null;
            try
            {
                createplace = table.CreateInstance<Createplace>();
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            return createplace;
        }
        [StepArgumentTransformation("the location details")]
        public Location theLocationDetails(Table table)
        {
            Location location = null;
            try
            {
                location = table.CreateInstance<Location>();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            return location;
        }
    }
}

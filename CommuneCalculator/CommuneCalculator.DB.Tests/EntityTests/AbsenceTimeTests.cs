using System;
using CommuneCalculator.DB.Entities;
using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace CommuneCalculator.DB.Tests.EntityTests
{
    [TestFixture]
    public class AbsenceTimeTests
    {

        private AbsenceTime _testAbsenceTime;

        [SetUp]
        public void SetupTests()
        {
            _testAbsenceTime = new AbsenceTime();
        }

        [Test]
        public void TestGetRoommate_ShouldReturnNull()
        {
            Null(_testAbsenceTime.Roommate);
        }

        [Test]
        public void TestGetAbsenceStart_ShouldReturnValueGreaterThanYesterday()
        {
            Greater(_testAbsenceTime.AbsenceStart, DateTime.Now.AddDays(-1));
        }

        [Test]
        public void TestGetAbsendeEnd_ShouldReturnValueGreaterThanToday()
        {
            Greater(_testAbsenceTime.AbsenceEnd, DateTime.Today);
        }
    }
}
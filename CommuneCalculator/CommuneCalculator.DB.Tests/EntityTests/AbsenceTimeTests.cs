using System;
using CommuneCalculator.DB.Entities;
using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace CommuneCalculator.DB.Tests.EntityTests
{
    [TestFixture]
    public class AbsenceTimeTests
    {
        [SetUp]
        public void SetupTests()
        {
            _testAbsenceTime = new AbsenceTime();
        }

        private AbsenceTime _testAbsenceTime;

        [Test(Author = "Peter Kurfer", TestOf = typeof(AbsenceTime))]
        public void TestGetAbsenceStart_ShouldReturnValueGreaterThanYesterday()
        {
            Greater(_testAbsenceTime.AbsenceStart, DateTime.Now.AddDays(-1));
        }

        [Test(Author = "Peter Kurfer", TestOf = typeof(AbsenceTime))]
        public void TestGetAbsendeEnd_ShouldReturnValueGreaterThanToday()
        {
            Greater(_testAbsenceTime.AbsenceEnd, DateTime.Today);
        }

        [Test(Author = "Peter Kurfer", TestOf = typeof(AbsenceTime))]
        public void TestGetRoommate_ShouldReturnNull()
        {
            IsNull(_testAbsenceTime.Roommate);
        }
    }
}
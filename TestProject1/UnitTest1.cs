using Moq;
using PasswordKeeper.App.Abstract;
using PasswordKeeper.App.Concrate;
using PasswordKeeper.App.Menagers;
using PasswordKeeper.Domain.Entity;
using FluentAssertions;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Password passwordBase = new Password();
            var mock = new Mock<IService<Password>>();
            mock.Setup(s => s.GetPasswordById(1)).Returns(passwordBase);
            var menager = new PasswordMenagers(new MenuActionService(), mock.Object);

            //act
            var returnedId = menager.PasswordShowById(passwordBase.Id);
            //Assert
            mock.Verify(m => m.GetPasswordById(0));
        }

        [Fact]
        public void IntegrationTest()
        {
            Password passwordBase = new Password(1, "Krystian07", "K5c3p7", 2);
            IService<Password> service = new PasswordService();
            service.AddPassword(passwordBase);
            var menager = new PasswordMenagers(new MenuActionService(), service);

            menager.Remove(passwordBase);

            // service.GetPasswordById(passwordBase.Id).Should().BeNull();
            service.Passwords.FirstOrDefault(p => p.Id == passwordBase.Id).Should().BeNull();
        }
    }

}
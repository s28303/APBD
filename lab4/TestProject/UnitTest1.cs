using LegacyApp;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void AddUser_Not_Enough_Years_Return_False()
        {
            // Arrange
            var userService = new UserService();

            // Act
            var result = userService.AddUser("Marek", "Montran", "marek.monrtan@example.com", new DateTime(2024, 4, 4), 1);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void AddUser_Invalid_Input_Return_False()
        {
            // Arrange
            var userService = new UserService();

            // Act
            var result = userService.AddUser("", "", "fefefe", new DateTime(22, 2, 2), 2);

            // Assert
            Assert.False(result);
        }
    }
}
namespace Domain.Tests;

[TestClass]
public class UserTests
{
    private User _user;

    [TestInitialize]
    public void Initialize()
    {
        _user = new User("Username", "email@example.com", "password!234.");
    }

    [TestMethod]
    public void CreateNewUser_WhenNameIsEmpty_ThenThrowsException()
    {
        //arrange
        //act and assert
        Exception exception = Assert.ThrowsException<ArgumentException>(() => _user.Name = "");
        Assert.AreEqual("Username cannot be empty", exception.Message);
    }

    [TestMethod]
    public void CreateNewUser_WhenNameIsValid_ThenNameIsAssigned()
    {
        //arrange
        //act
        //assert
        Assert.AreEqual("Username", _user.Name);
    }

    [TestMethod]
    public void CreateNewUser_WhenEmailIsEmpty_ThenThrowsException()
    {
        //arrange
        //act and assert
        Exception exception = Assert.ThrowsException<ArgumentException>(() => _user.Email = "");
        Assert.AreEqual("Email cannot be empty", exception.Message);
    }

    [TestMethod]
    public void CreateNewUser_WhenEmailIsInvalid_ThenThrowsException()
    {
        //arrange
        //act and assert
        Exception exception = Assert.ThrowsException<ArgumentException>(() => _user.Email = "@usermail.com");
        Assert.AreEqual("Email format is invalid", exception.Message);
    }

    [TestMethod]
    public void CreateNewUser_WhenEmailIsValid_ThenEmailIsAssigned()
    {
        //arrange
        //act
        //assert
        Assert.AreEqual("email@example.com", _user.Email);
    }

    [TestMethod]
    public void CreateNewUser_WhenPasswordIsEmpty_ThenThrowsException()
    {
        //arrange
        //act and assert
        Exception exception = Assert.ThrowsException<ArgumentException>(() => _user.Password = "");
        Assert.AreEqual("Password cannot be empty", exception.Message);
    }

    [TestMethod]
    public void CreateNewUser_WhenPasswordLengthIsInvalid_ThenThrowsException()
    {
        //arrange
        //act and assert
        Exception exception = Assert.ThrowsException<ArgumentException>(() => _user.Password = "pass.1");
        Assert.AreEqual("Password must have at least 8 characters", exception.Message);
    }

    [TestMethod]
    public void CreateNewUser_WhenPasswordDoesNotHaveAnySpecialChar_ThenThrowsException()
    {
        //arrange
        //act and assert
        Exception exception = Assert.ThrowsException<ArgumentException>(() => _user.Password = "pass1234");
        Assert.AreEqual("Password must have at least one special char", exception.Message);
    }

    [TestMethod]
    public void CreateNewUser_WhenPasswordIsValid_ThenPasswordIsAssigned()
    {
        //arrange
        //act
        //assert
        Assert.AreEqual("password!234.", _user.Password);
    }
}
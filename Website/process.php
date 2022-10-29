<?php
session_start();
  require_once('php/connection.php');

  //Log In
  if(isset($_POST['Login'])){
    //Check if form is filled
    if(empty($_POST['logInEmail']) || empty($_POST['logInPassword'])){
        header("location:index.php?Empty=Please fill in the blanks");
    }
    else{
      $query = "select * from users where Email='".$_POST['logInEmail']."' and Password='".$_POST['logInPassword']."'";
      $result = mysqli_query($con, $query);
      if(mysqli_fetch_assoc($result)){
        $_SESSION['User'] = $_POST['logInEmail'];
        $_SESSION['cart'] = array();
        header("location:home.php");
      }
      else{
        header("location:index.php?Invalid=Please enter correct email and password");
      }
    }
  }
  else if(isset($_POST['Signup'])){
    //Check if form is filled
    if(empty($_POST['signUpFirstName']) || empty($_POST['signUpLastName']) || empty($_POST['signUpSex']) || empty($_POST['signUpAge']) || empty($_POST['signUpEmail']) || empty($_POST['signUpPassword'])){
        header("location:index.php?Empty=Please fill in the blanks");
    }
    else{
      //Check if user exists
      $checkQuery = "select * from users where Email='".$_POST['signUpEmail']."'";
      $checkResult = mysqli_query($con, $checkQuery);
      if(mysqli_fetch_assoc($checkResult)){
        header("location:index.php?Invalid=Error! An account already exists with that email!");
      }
      else{
        //Create user
        $query = "insert into users(FirstName,LastName,Age,Sex,Email,Password) values('".$_POST['signUpFirstName']."', '".$_POST['signUpLastName']."', '".$_POST['signUpAge']."', '".$_POST['signUpSex']."', '".$_POST['signUpEmail']."', '".$_POST['signUpPassword']."')";
        $result = mysqli_query($con, $query) or die(mysqli_error());
        if($result){
          $_SESSION['User'] = $_POST['signUpEmail'];
          $_SESSION['cart'] = array();
          header("location:home.php");
        }
      }
    }
  }

?>

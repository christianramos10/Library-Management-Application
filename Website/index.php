<?php
  require 'php/connection.php';
  require 'process.php';

?>
<!DOCTYPE html>
<html lang="en" dir="ltr">
  <head>
    <meta charset="utf-8">
    <link rel="icon" href="img/favicon.png">
    <title>Index</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous">
    <link rel="stylesheet" href="css/index.css">
</head>
  <body>
    <div class="bg-img"></div>
    <div class="container">
      <h1 class="welcomeLabel">Welcome to My Library</h1>
      <div class="row inner-row">
        <div class="col-lg-5 col-md-7">
          <!-- Log In Form -->
          <div class="form-box p-md-5 p-3 login-form">
            <!-- Form Title -->
            <div class="form-title">
              <h2 class="fw-bold mb-3">Login</h2>
            </div>
            <!-- Php error msg -->
            <?php
              if(@$_GET['Empty']==true){
            ?>
            <div class="alert-light text-danger text-center p-3">
              <?php echo $_GET['Empty']?>
            </div>

            <?php
              }
            ?>

            <?php
              if(@$_GET['Invalid']==true){
            ?>
            <div class="alert-light text-danger text-center p-3">
              <?php echo $_GET['Invalid']?>
            </div>

            <?php
              }
            ?>

            <!-- Form Body -->
            <form action="process.php" method="post">
              <div class="form-floating mb-3">
                <input type="email" class="form-control form-control-sm" placeholder="Email" id="floatingLogInEmail" name="logInEmail">
                  <label for="floatingLoginEmail">Email</label>
              </div>
              <div class="form-floating mb-3">
                <input type="password" class="form-control form-control-sm" placeholder="Password" id="floatingLoginPassword" name = "logInPassword">
                  <label for="floatingLogInPassword">Password</label>
              </div>
              <div class="mt-3">
                <input type='submit' name="Login" class="btn btn-dark btn-lg text-white logInBtn" value="Log In">
                <!-- <button class="btn btn-dark btn-lg text-white logInBtn" type="submit" name="Login">Log In</button> -->
              </div>
            </form>
            <div class="mt-3">
              <span>Don't have account?</span> <button class="p-0 border-0 bg-transparent primaryColor signup-show">Sign Up</button>
            </div>
          </div>

          <!-- Sign Up Form -->
          <div class="form-box p-md-5 p-3 signup-form">
            <!-- Form Title -->
            <div class="form-title">
              <h2 class="fw-bold mb-3">Sign Up</h2>
            </div>
            <!-- Form Body -->
            <form action="process.php" method="post">
              <div class="form-floating mb-3">
                <input type="text" class="form-control form-control-sm" placeholder="First Name" id="floatingFirstName" name="signUpFirstName">
                  <label for="floatingFirstName">First Name</label>
              </div>
              <div class="form-floating mb-3">
                <input type="text" class="form-control form-control-sm" placeholder="Last Name" id="floatingLastName" name="signUpLastName">
                  <label for="floatingLastName">Last Name</label>
              </div>
              <div class="form-floating mb-3">
                <input type="text" class="form-control form-control-sm" placeholder="Age" id="floatingAge" name="signUpAge">
                  <label for="floatingAge">Age</label>
              </div>
              <div class="form-floating mb-3">
                <input type="text" class="form-control form-control-sm" placeholder="Sex" id="floatingSex" name="signUpSex">
                  <label for="floatingSex">Sex (M/F/O)</label>
              </div>
              <div class="form-floating mb-3">
                <input type="email" class="form-control form-control-sm" placeholder="Email" id="floatingSignUpEmail" name="signUpEmail">
                  <label for="floatingSignUpEmail">Email</label>
              </div>
              <div class="form-floating mb-3">
                <input type="password" class="form-control form-control-sm" placeholder="Password" id="floatingSignUpPassword" name="signUpPassword">
                  <label for="floatingSignUpPassword">Password</label>
              </div>
              <div class="mt-3">
                <input type='submit' name="Signup" class="btn btn-dark btn-lg text-white signUpBtn" value="Register">
              </div>
            </form>
            <div class="mt-3">
              <span>Already have account?</span> <button class="p-0 border-0 bg-transparent primaryColor login-show">Login</button>
            </div>
          </div>

        </div>

      </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-OERcA2EqjJCMA+/3y+gxIOqMEjwtxJY7qPCqsdltbNJuaOe923+mo//f6V8Qbsw3" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
    <script>
      $('.signup-show').click(function(){
        $('.signup-form').show();
        $('.login-form').hide();
      });

      $('.login-show').click(function(){
        $('.login-form').show();
        $('.signup-form').hide();
      });

    </script>
  </body>
</html>

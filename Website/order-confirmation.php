<?php require 'process.php';?>

<!DOCTYPE html>
<html lang="en" dir="ltr">
  <head>
    <meta charset="utf-8">
    <title>My Library</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous">
    <link rel="stylesheet" href="css/home.css">
  </head>
  <body>

    <!-- Navbar -->
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
      <a class="navbar-brand" href="">My Library</a>
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>

      <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav mr-auto">
          <li class="nav-item">
            <a class="nav-link" href="home.php">Home</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="my-order.php">My Order</a>
          </li>
          <li class="nav-item">
            <form action="search.php" method="post">
              <input class="form-control mr-sm-2" type="search" placeholder="Search Title" aria-label="Search" name="SearchText">
            </form>
          </li>
          <li class="nav-item">
            <a href="search.php"><input type="button" class="btn btn-dark btnSearch" name="Search" value="Search"></a>
          </li>
        </ul>
        <ul class="navbar-nav ms-auto">
          <li class="nav-item">
            <h4>Welcome <span class="badge badge-secondary"><?php echo ($_SESSION['User']); ?></span></h4>
          </li>
          <li class="nav-item active">
            <a class="nav-link" href="cart.php">Cart</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="logout.php?Logout">Log Out</a>
          </li>
        </ul>
      </div>
    </nav>

    <div class="container">
      <div class="confirmation">

        <?php
          $totalBooks = "";
          $status = "pending";
          //Check if user doesn't have an order
          $checkQuery = "select * from orders where Email = '".$_SESSION['User']."' and orderStatus != 'handedIn'";
          $resultCheck = mysqli_query($con, $checkQuery);
          if(empty($_SESSION['cart'])){header("location:cart.php");}

          if(isset($_GET['id']) == "confirm"){
            if(!(empty($_SESSION['cart'])) and !(mysqli_fetch_assoc($resultCheck))){
              //Modify db table
              foreach ($_SESSION['cart'] as $book) {
                $totalBooks = $totalBooks . $book . " ";
                $updt = "update books set Available = Available-1, Rented = Rented+1 where ISBN='".$book."'";
                $resultUpdt = mysqli_query($con, $updt);
              }

              //Get order dates
              $orderDate = date("y-m-d");
              $pickUpDate = date("y-m-d", strtotime($orderDate . "+ 1 day"));
              $returnDate = date("y-m-d", strtotime($pickUpDate . "+ 10 days"));

              //Insert Order
              $insrt = "insert into orders(email,books,initialDate,pickUpDate,returnDate,orderStatus) values('".$_SESSION['User']."', '".$totalBooks."','".$orderDate."','".$pickUpDate."','".$returnDate."','".$status."')";
              $resultInsrt = mysqli_query($con, $insrt);

              //Empty cart
              $_SESSION['cart'] = array();

              //Add confirmation to user
              $idSel = "select ID from orders where Email='".$_SESSION['User']."'";
              $resultID = mysqli_query($con, $idSel);
              $orderID = mysqli_fetch_array($resultID);

              echo "<p>
                Order confirmed with ID# '".$orderID['ID']."', your order should be ready to pick up by '".$pickUpDate."' and must be returned by '".$returnDate."'
              </p>";
            }

            else {
              echo "<p>
              Whoops! There was a problem with your order. Please verify that you don't have any order still running. If the problem persists, please contact support.
              </p>";
            }
          }
        ?>

        <a href="home.php"><button class="btn btn-dark" name="button">Continue Browsing</button></a>
        <a href="logout.php?Logout"><button class="btn btn-dark" name="button">Log Out</button></a>
      </div>
    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-OERcA2EqjJCMA+/3y+gxIOqMEjwtxJY7qPCqsdltbNJuaOe923+mo//f6V8Qbsw3" crossorigin="anonymous"></script>
    <script type="text/javascript">

    </script>
  </body>
</html>

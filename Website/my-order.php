<?php
  require 'process.php';

  if($_SERVER['REQUEST_METHOD'] == 'POST' && $_POST['_METHOD'] == 'DELETE' && $_SESSION['order-status'] == 'pending'){

    $booksInOrder = explode(" ", $_SESSION['order-books']);
    foreach ($booksInOrder as $book) {
      if($book != "" && $book != " ")
      $updt = "update books set Available = Available+1, Rented = Rented-1 where ISBN='".$book."'";
      $resultUpdt = mysqli_query($con, $updt);
    }

    $query = "delete from orders where email='".$_SESSION['User']."'";
    $result = mysqli_query($con, $query);

    if($result){
      header("location:my-order.php");
    }
  }
?>
<!DOCTYPE html>
<html lang="en" dir="ltr">
  <head>
    <meta charset="utf-8">
    <title>My Orders</title>
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
          <li class="nav-item active">
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
          <li class="nav-item">
            <a class="nav-link" href="cart.php">Cart</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="logout.php?Logout">Log Out</a>
          </li>
        </ul>
      </div>
    </nav>

    <div class="container">
        <!-- Get info from orders table -->
        <?php
          $query = "select * from orders where email='".$_SESSION['User']."' and orderStatus != 'handedIn'";
          $result = mysqli_query($con, $query);
          $check_books = mysqli_num_rows($result)>0;

          if($check_books){
            $row = mysqli_fetch_array($result);

            $_SESSION['order-status'] = $row['orderStatus'];
            $_SESSION['order-books'] = $row['books'];

            echo "<h3>Your last order was:</h3>";
            echo "<h4>ID: '".$row['ID']."'</h4>";
            echo "<h4>Pick-Up date: '".$row['pickUpDate']."'</h4>";
            echo "<h4>Return date: '".$row['returnDate']."'</h4>";
            echo "<h4>Order Status: '".$row['orderStatus']."'</h4>";
            echo "<h4>Your order's books:</h4>";
            ?>
            <div class="row justify-content-center mb-3">
              <?php

              $orderedBooks = explode(" ", $row['books']);
              for($index = 0; $index<count($orderedBooks); $index++) {
                if(strlen($orderedBooks[$index])>1){
                  $query = "select * from books where ISBN='".$orderedBooks[$index]."'";
                  $result = mysqli_query($con, $query);
                  if($result){
                    $bookRow = mysqli_fetch_array($result);
                    ?>
                      <div class="col-lg-2 col-md-6 col-sm-12 d-flex align-items-stretch gx-5 gy-5">
                        <div class="card">
                          <div class="card-body d-flex flex-column">
                            <img src="<?php echo ($bookRow['CoverURL'])?>" class="card-img-top mb-2" alt="Book Cover">
                            <h2 class="card-title"><?php echo $bookRow['Title'];?></h2>
                            <p class="card-text author">By: <?php echo $bookRow['Author'];?></p>
                            <p class="card-text"><?php echo $bookRow['Description'];?></p>
                          </div>
                        </div>
                      </div>
                    <?php
                    }
                  }
                }
                ?>
            </div>
            <form method="post" onsubmit="return Confirm('Are you sure you want to cancel the order?')">
              <input type="hidden" name="_METHOD" value="DELETE">
              <button type="submit" class="btn btn-danger">Cancel Order</button>
            </form>
            <?php
          }
          else{
            echo "<h4 class='mt-5 mb-5'>You don't have any opened order.</h4>";
            ?>
            <a href="home.php"><button type="button" class="btn btn-dark" name="button">Browse Books</button></a>
            <?php
          }
        ?>
    </div>


    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-OERcA2EqjJCMA+/3y+gxIOqMEjwtxJY7qPCqsdltbNJuaOe923+mo//f6V8Qbsw3" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
  </body>
</html>

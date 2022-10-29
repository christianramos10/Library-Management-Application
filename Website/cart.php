<?php
require 'process.php';
error_reporting(E_ERROR | E_PARSE);

if(isset($_GET['id'])){
  $temp = $_SESSION['cart'];
  if (($key = array_search($_GET['id'], $temp)) !== false) {
    unset($temp[$key]);
  }
  $_SESSION['cart'] = $temp;
  $_SESSION['count']--;
  header("location:cart.php");
}
 ?>
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

    <!-- Books -->
    <div class="container mt-5">
      <table class="table">
        <thead>
          <tr>
            <th scope='col'>Title</th>
            <th scope='col'>Edit</th>
          </tr>
        </thead>
        <tbody>


          <!-- Select books from cart -->
          <?php
            require 'php/connection.php';
            $bookISBN = implode(',', $_SESSION['cart']);
            $qry = "Select Title, ISBN from books where ISBN IN($bookISBN)";
            $result = mysqli_query($con, $qry);
            $check_books = mysqli_num_rows($result)>0;

            if($check_books){
              while($row = mysqli_fetch_array($result)){

                //Add Books to Cards
                ?>
                <tr>
                  <th scope="row"><?php echo $row['Title'];?></th>
                  <td><a href="?id=<?php echo $row['ISBN'];?>"><input type="button" class="btn btn-danger mt-auto btnRemove" name="" value="Remove"></a></td>
                </tr>
                <?php
              }
            }
            else{
              echo "<h3 id='emptyLabel'>Your Cart Is Empty.</h3>";
            }
          ?>
        </tbody>
      </table>
      <a href="order-confirmation.php?id=confirm" id="btnConfirm"><input type="button" class="btn btn-dark mt-auto" name="" value="Confirm"></a>
      <a href="home.php"><input type="button" class="btn btn-dark mt-auto btnBrowse" name="" value="Continue Browsing"></a>
    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-OERcA2EqjJCMA+/3y+gxIOqMEjwtxJY7qPCqsdltbNJuaOe923+mo//f6V8Qbsw3" crossorigin="anonymous"></script>
    <script type="text/javascript">
      if($('#emptyLabel').length){
        $('#btnConfirm').remove();
      }

    </script>
  </body>
</html>

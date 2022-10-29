<?php
  require ('process.php');
  error_reporting(E_ERROR | E_PARSE);

  if(isset($_POST['Search']) and !(empty($_POST['Search']))){
    $_SESSION['search'] = $_POST['SearchText'];
  }
  if(isset($_GET['id']) and (strpos($_GET['id'], 'search') === false)){
      if(empty($_SESSION['cart'])){
        $_SESSION['cart'] = array();
        $_SESSION['count'] = 0;
      }
      array_push($_SESSION['cart'], $_GET['id']);
      $_SESSION['count']++;
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
          <li class="nav-item active">
            <a class="nav-link" href="home.php">Home</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="my-order.php">My Order</a>
          </li>
          <li class="nav-item">
            <form action="search.php" method="post">
              <div class="row">
                <div class="col">
                  <input class="form-control mr-sm-2" type="search" placeholder="Search Title" aria-label="Search" name="SearchText">
                </div>
                <div class="col">
                  <input type='submit' name="Search" class="btn btn-dark text-white btnSearch" value="Search">
                </div>
              </div>
            </form>
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

    <!-- Books -->
    <div class="book-container">
      <div class="row justify-content-center">

        <!-- Select books from db -->
        <?php
          require 'php/connection.php';
          $qry = "Select * from books where Title like '%".$_SESSION['search']."%' and Available>0";
          $result = mysqli_query($con, $qry);
          $check_books = mysqli_num_rows($result)>0;

          if($check_books){
            while($row = mysqli_fetch_array($result)){
              //Add Books to Cards
              $isbn = $row['ISBN'];
              ?>
              <div class="col-lg-3 col-md-6 col-sm-12 d-flex align-items-stretch gx-5 gy-5">
                <div class="card">
                  <div class="card-body d-flex flex-column">
                    <img src="<?php echo ($row['CoverURL'])?>" class="card-img-top mb-2" alt="Book Cover">
                    <h2 class="card-title"><?php echo $row['Title'];?></h2>
                    <p class="card-text"><?php echo $row['Description'];?></p>

                    <!-- If book is in cart, disable button -->
                    <?php
                    $temp = $_SESSION['cart'];
                    if(count($temp)>0){
                      if (($key = array_search($row['ISBN'], $temp)) !== false) {
                        ?>
                        <a href="" class="mt-auto"><input type="button" class="btn btn-secondary" name="" value="Book In Cart"></a>
                        <?php
                      }
                      else{
                        ?>
                        <a href="?id=<?php echo $isbn;?>" class="mt-auto"><input type="button" class="btn btn-dark btnAdd" name="" value="Add"></a>
                        <?php
                      }
                    }
                    else{
                      ?>
                      <a href="?id=<?php echo $isbn;?>" class="mt-auto"><input type="button" class="btn btn-dark btnAdd" name="" value="Add"></a>
                      <?php
                    }
                    ?>
                  </div>
                </div>
              </div>
              <?php
            }
          }
          else{
            echo "No Books Found";
          }
        ?>
      </div>
    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-OERcA2EqjJCMA+/3y+gxIOqMEjwtxJY7qPCqsdltbNJuaOe923+mo//f6V8Qbsw3" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
    <script type="text/javascript">

    </script>
  </body>
</html>

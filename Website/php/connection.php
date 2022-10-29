<?php
  //Create connection -> libraryAdmin, #Admin123
  $con = mysqli_connect('localhost', 'libraryAdmin', '#Admin123', 'mylibrary');

  if(!$con){echo 'Connection error: ' . mysqli_connect_error();}
 ?>

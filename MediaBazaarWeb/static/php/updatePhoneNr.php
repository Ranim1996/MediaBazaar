<?php

    require('dbConnection.php');

    session_start();

    if(isset($_POST['submit']))
    {
       $phone = $_POST['phone'];
       $username = $_SESSION['username'];
       $query = "UPDATE employee SET PhoneNumber = '$phone' WHERE Username = '$username'";

       $stmt = $conn->prepare($query);
       $stmt->execute();

       header('Location: /mediaBazaar/homePage.php');
    }
?>
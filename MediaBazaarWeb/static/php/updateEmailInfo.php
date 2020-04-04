<?php

    require('dbConnection.php');

    session_start();

    if(isset($_POST['submit']))
    {
        
        $email = $_POST['email'];
        $username = $_SESSION['username'];
        $query = "UPDATE employee SET Email = '$email' WHERE Username = '$username'";

        $stmt = $conn->prepare($query);
        $stmt->execute();

        header('Location: /mediaBazaar/homePage.php');
    }
?>
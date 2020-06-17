<?php

    require('dbConnection.php');

    session_start();

    if(isset($_POST['submit']))
    {
        $password = $_POST['new-password'];
        //change the session password 
        $_SESSION['password'] = $password;
        $username = $_SESSION['username'];
        $query = "UPDATE employee SET Password = '$password', FirstLogin='1' WHERE Username = '$username'";

        $stmt = $conn->prepare($query);
        $stmt->execute();

        header('Location: /mediaBazaar/homePage.php');
    }

?>
<?php

    require('dbConnection.php');

    session_start();

    if(isset($_POST['submit']))
    {
        $bio = $_POST['new-bio'];

        $username = $_SESSION['username'];
        $query = "UPDATE employee SET PersonalInfo = '$bio' WHERE Username = '$username'";

        $stmt = $conn->prepare($query);
        $stmt->execute();

        header('Location: /mediaBazaar/homePage.php');
    }
?>
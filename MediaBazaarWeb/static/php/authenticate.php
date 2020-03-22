<?php 

require('dbConnection.php');
//header('location: homePage.php');
//include('mediaBazaar/homePage.php');
session_start();

if(isset($_POST['submit']))
{
    if(empty($_POST["username"]) || empty($_POST["password"]))
    {
        $message = '<label>All fields are required</label>';
        echo $message;
    }
    else
    {
        $query = "SELECT * FROM employee WHERE username = :username AND password = :password";
        $statement = $conn->prepare($query);
        $statement->execute(
            array(
                'username' => $_POST["username"],
                'password' => $_POST["password"]
            )
        );
        $count = $statement->rowCount();
        if($count > 0)
        {
            $_SESSION['loggedin'] = TRUE;
		    $_SESSION['password'] = $_POST['password'];
            $_SESSION['username'] = $_POST["username"];
	        header('Location: /mediaBazaar/homePage.php');
            exit;
            //echo "Profile page";
        }
        else
        {
            $message = "Wrong data inserted";
            echo $message;
        }
    }
}

?>

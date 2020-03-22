<?php 
  session_start();
  if(!isset($_SESSION['loggedin'])){
    header('Location: loginPage.html');
    exit;
  }
  require('static/php/dbConnection.php');

  $username = $_SESSION['username'];
  $password = $_SESSION['password'];

  $query_employee = "SELECT * FROM employee WHERE Username = '$username' AND Password = '$password' ";
  $employee_statement = $conn->prepare($query_employee);
  $employee_statement->execute();
  $employees = $employee_statement->fetchAll();
  $employee_statement->closeCursor();  
?>

<!DOCTYPE html>
<html lang="en">
<head>
  <link rel="stylesheet" type="text/css" href="static/css/main.css">
  <link rel="stylesheet" type="text/css" href="static/css/normalize.css">
  <link rel="stylesheet" type="text/css" href="static/css/ionicons-master/docs/css/ionicons.min.css">
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
  <link href="https://fonts.googleapis.com/css?family=Lato:100,300,300i,400&display=swap" rel="stylesheet">
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width,initial-scale=1,maximum-scale=1,user-scalable=no">
  <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
  <meta name="HandheldFriendly" content="true">
  <title>Media Bazaar</title>
</head>

<body class="body-home-page">

    <header class="header-home" id="home">

      <nav>
        <div class="row">
          <a href="#home"><img alt="logo" class="logo-nav" src="static/img/logo2.png"></a>
          <ul class="main-nav">
              <li><a href="#home">Home</a></li>
              <li><a href="#schedule">Schedule</a></li>
          </ul>

          <div class="main-nav logout">
            <a href="#">Log Out</a>
          </div>
        </div>
      </nav>

    </header>


    <section class="home-page-cover-wallpaper-section">

      <div class="content-block">
        <div class="row">
          <img src="static/img/wallpaper.jpg" alt="wallpaper" class="cover-picture">
        </div>
        <?php foreach($employees as $employee) ?>
        <div class="wallpaper-personal-info">
          <div class="wallpaper-box-content-personal-info">
            <div class="wallpaper-title-box-inside">
              <div class="text-edit-personal-info">
               <!-- Name from the database -->
                <h1><?php  
                  echo $employee['FirstName'] . " " . $employee['LastName'];
                ?></h1>
                <div class="job-position">
                  <i class="ion-ios-man"></i>
                  <h3><?php echo $employee['Position']; ?></h3>   <!-- Position from the database -->
                </div>
                <div class="department">
                  <i class="ion-ios-locate"></i>
                  <h3><?php 
                  if($employee['Departament'] == NULL)
                  {
                    $message = "Not yet assigned to department";
                    echo $message;
                  }
                  else
                  {
                    echo $employee['Departament'];
                  }
                   ?></h3>    <!-- Department from the database -->
                </div>
               
                <div class="started-date">
                  <i class="ion-ios-calendar"></i>
                  <h3><?php echo "Borned on: " . $employee['DateOfBirth']; ?></h3>     <!-- Born date from the database -->
                </div>
              </div>
            </div>
          </div>
        </div>

        <div class="container-personal-picture">
          <div class="container-profile-pic">
            <div class="profile-picture">

            </div>
            <i class="ion-ios-build icon-customize customize-profile-picture"></i>
          </div>

            <div class="content-below-profile-picture">
              <h2 class="work-shift-title">Work shifts this week</h2>
              <ul>
                <li><h4 class="days-work-shifts">Tuesday: 9:00 - 12:00</h4></li>
                <li><h4 class="days-work-shifts">Tuesday: 9:00 - 12:00</h4></li>
                <li><h4 class="days-work-shifts">Tuesday: 9:00 - 12:00</h4></li>
                <li><h4 class="days-work-shifts">Tuesday: 9:00 - 12:00</h4></li>
                <li><h4 class="days-work-shifts">Tuesday: 9:00 - 12:00</h4></li>
                <li><h4 class="days-work-shifts">Tuesday: 9:00 - 12:00</h4></li>
                <li><h4 class="days-work-shifts">Tuesday: 9:00 - 12:00</h4></li>
                <li><h4 class="days-work-shifts">Tuesday: 9:00 - 12:00</h4></li>
                <li><h4 class="days-work-shifts">Tuesday: 9:00 - 12:00</h4></li>
              </ul>
            </div>

        </div>

      </div>
    </section>


    <!-- CONTACT SECTION-->
    <section class="home-page-section">
      <div class="row">
        <h2 class="home-content">Contact</h2>

        <div class="email">
          <i class="ion-ios-mail"></i>
          <h3 class="header3-profilePage">Email</h3>
        </div>
          <p id="mail-written"><?php echo $employee['Email']; ?></p>

        <div class="phone-number">
          <i class="ion-ios-call"></i>
          <h3 class="header3-profilePage">Mobile</h3>
        </div>
          <p id="phone-nr"><?php echo $employee['PhoneNumber']; ?></p>

          <div class="customize-home-section">
            <i class="ion-ios-build  icon-customize icon-customize-contact-section"></i>
          </div>
       
        
        
      </div>
    </section>



    <!-- ACCOUNT CREDENTIALS SECTION-->
    <section class="home-page-section">
      <div class="row">
        <h2 class="home-content">Account Credentials</h2>

        <div class="username-homePage">
          <i class="ion-ios-person"></i>
          <h3 class="header3-profilePage">Username</h3>
        </div>
          <p><?php echo $employee['Username']; ?></p> 

        <div class="password-homePage">
          <i class="ion-ios-key"></i>
          <h3 class="header3-profilePage">Password</h3>
        </div>
          <p>***************</p>

          <div class="customize-home-section">
            <i class="ion-ios-build  icon-customize icon-customize-contact-section"></i>
          </div>
      </div>
    </section>



    <!-- ABOUT SECTION-->
    <section class="home-page-section">
      <div class="row">
        <h2 class=" home-content">About</h2>

        <div class="biography">
          <h3>Bio</h3>
        </div>
        <p id="personal-bio">Lorem ipsum dolor sit amet, consectetur adipiscing elit.
          Cras vel maximus felis. Integer malesuada lorem libero, vel ultricies ipsum
          ultrices eget. Quisque molestie lectus ut dui scelerisque aliquet. Donec vestibulum
          e. </p>

        <div class="customize-home-section">
          <i class="ion-ios-build  icon-customize icon-customize-bio-section"></i>
        </div>
        
      </div>
    </section>


    <footer>
      <div class="row">

        <div class="col span-1-of-2">
          <ul class="footer-nav">
            <li><a href="#">About Us</a></li>
            <li><a href="#">Blog</a></li>
            <li><a href="#">Services</a></li>
          </ul>
        </div>

        <div class="col span-1-of-2">
          <ul class="social-links">
            <li><a href="#"><i class="ion-logo-facebook"></i> </a> </li>
            <li><a href="#"><i class="ion-logo-instagram"></i> </a></li>
            <li><a href="#"><i class="ion-logo-twitter"></i></a></li>
          </ul>
        </div>
      </div>

      <div class="row">
        <p id="footer-p">
          Copyright &copy; 2020 by EasySoft. All rights reserved.
        </p>
      </div>
    </footer>

</body>
</html>

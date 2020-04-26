<?php

session_start();

require('static/php/dbConnection.php');

//ranim part
$selectedDate = "";
$weekDay = "";

if (isset($_GET['date'])) {
	# code...
	//change the format of the selected date d/m/Y
	$selectedDate = $_GET['date'];
	$formatDate = date('d/m/Y', strtotime(($selectedDate)));

	//get the day of week name for the shifts
	$weekDay = date('l/m/Y', strtotime($selectedDate));
	$weekDay = explode('/', $weekDay);
	$dayOfWeek = $weekDay[0];

}

//DOES NOT work for now
// function checkDuplicate($shift, $date){
// 	require('static/php/dbConnection.php');
// 	$id = $_SESSION['employeeId'];
// 	$query = "SELECT Date, Shift FROM schedule WHERE EmployeeID = '$id'";
// 	$info = $conn->prepare($query);
// 	$info->execute();
// 	$information = $info->fetchAll();
// 	$info->closeCursor();
// 	foreach($information as $f)
// 	{
// 		if($dateDB == $f['Date'] && $shiftDB == $f['Shift'])
// 		{
// 			return false;
// 		}
// 	}
// 	return true;
// }

// if (isset($_POST['submit'])) {

// 	require('static/php/dbConnection.php');

// 	$EmployeeID = $_SESSION['employeeId'];
// 	$shift = $_POST['timeslot'];
// 	echo $shift;
// 	echo $formatDate;
// 	$status = 'Selected';

	//check if the preference already exists in the schedule table
	//avoid duplicating information in the db

	// if(checkDuplicate($shift, $formatDate) == true)
	// {
		// $query = "SELECT * FROM schedule where date=? AND timeslot =?";
		// $stmt = $conn->prepare($query);
		// if($stmt->execute()) {
		// 	# code...
		// 	// $result = $stmt->get_result();
		// 	$result = $stmt;
		// 	if ($result->rowCount()>0) {
		// 		# code...
				
		// 	}else{
				// if ($shift != "" && $formatDate != "") {
					// $query = "INSERT INTO schedule (EmployeeID, Date, Shift, Status) VALUES ( '$EmployeeID' , '$formatDate', '$shift', '$status')";
					// $stmt = $conn->prepare($query);
					// $stmt->execute();
					// $selection[]=$timeslot;
					// header('Location: calendar.php');
				//}
			///}
		//}
	// }
	// else
	// {
	// 	include('static/php/prefferenceError.php');
	// }

	// $conn = null;
//}

if (isset($_POST['submit'])) {
	//select day to work in
	$EmployeeID = $_SESSION['employeeId'];
	$shift = $_POST['timeslot'];
	echo $shift;
	echo $formatDate;
	$status = 'Selected';

	if ($shift != "" && $formatDate != "") {
		$query = "INSERT INTO schedule (EmployeeID, Date, Shift, Status) VALUES ( '$EmployeeID' , '$formatDate', '$shift', '$status')";
		$stmt = $conn->prepare($query);
		$stmt->execute();
		header('Location: calendar.php');
	}
}

function timeslots($day)
{
	//showing shifts
	$slots = array();
	if ($day == "Sunday") { //sunday shift
		$slots[0] = "12:00-18:00";
	} else {
		if ($day == "Saturday") { //saturday shifts
			$slots[0] = "9:00-15:00";
			$slots[1] = "15:00-18:00";
		} else { // other days shifts
			$slots[0] = "07:00-12:00";
			$slots[1] = "12:00-17:00";
			$slots[2] = "17:00-22:00";
		}
	}
	return $slots;
}


?>



<!DOCTYPE html>
<html lang="en">

<head>
	<meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content="ie=edge">
	<meta name="viewport" content="width = device, initial-scale = 1.0">
	<link rel="stylesheet" type="text/css" href="static/css/main.css">
	<link rel="stylesheet" type="text/css" href="static/css/ionicons-master/docs/css/ionicons.min.css">
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">

</head>

<body class="body-calendar-page">

	<header class="header-home" id="home">

		<nav>
			<div class="nav-calendar">
				<a href="#home"><img alt="logo" class="logo-nav" src="static/img/logo2.png"></a>
				<ul class="main-nav calendar-nav">
					<li><a href="homePage.php">Home</a></li>
					<li><a href="calendar.php">Shedule</a></li>
				</ul>

				<div class="main-nav logout logout-calendar">
					<a href="loginPage.html">Log Out</a>
				</div>
			</div>
		</nav>

	</header>
	<div class="container container-select-shift">
		<h1 class="text-center">Selected Date: <?php echo  $formatDate ?> </h1>
		<hr>
		<div class="row">
			<?php $timeslots = timeslots($dayOfWeek);
			foreach ($timeslots as $ts) {
			?>
				<div class="col-md-2">
					<div>
						<button class="btn btn-success Select" data-timeslot="<?php echo $ts; ?>"><?php echo $ts; ?></button>
					</div>
				</div>
			<?php } ?>
		</div>

		<div class="modal-header">
			<h4 class="modal-title">Selected: <span id="slot"></span> </h4>
		</div>
		<div class="modal-body">
			<div class="row">
				<div class="col-md-12">
					<form action="" method="post">
						<div class="form-group">
							<label for=""> Timeslot</label>
							<input required type="text" readonly name="timeslot" id="timeslot" class="timeslot-select">
						</div>
						<div class="form-group pull-right">
							<button class="btn btn-primary" type="submit" name="submit">Request</button>
						</div>
					</form>
				</div>
			</div>
		</div>

	</div>


	<footer class="footer-calendar">
		<div class="row-footer">

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

		<div class="row-footer">
			<p id="footer-p">
				Copyright &copy; 2020 by EasySoft. All rights reserved.
			</p>
		</div>
	</footer>

	<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
	<script>
		$(".Select").click(function() {
			var timeslot = $(this).attr('data-timeslot');
			$("#slot").html(timeslot);
			$("#timeslot").val(timeslot);
			$("#myModal").modal("show");
		})
	</script>

</body>

</html>
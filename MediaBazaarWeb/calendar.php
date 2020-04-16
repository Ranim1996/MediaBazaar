<?php

function build_calendar($month, $year){

	//require('static/php/dbConnection.php');
	/*$stmt = $mysqli->prepare("SELECT * FROM schedule WHERE Month(date)=? AND Year(date) = ?");
	$stmt->bind_param('ss', $month, $year);
	$selection = array();
	if ($stmt->execute()) {
		# code...
		$result = $stmt->get_result();
		if ($result->num_rows>0) {
			# code...
			while ($row = $result->fetch_assoc(stmt)) {
				# code...
				$selection[] = $row['date'];
			}
		}

		$stmt->close();
	}
	*/

	//names of days
	$daysOfWeek = array ('Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday');

	//get first day of the month
	$firstDayOfMonth = mktime(0,0,0,$month, 1,$year);

	//get number of days for each month
	$numberDays = date('t', $firstDayOfMonth);

	//get info about day
	$dateComponents = getdate($firstDayOfMonth);

	//get name of month
	$monthName = $dateComponents['month'];

	//get index value 0-6
	$dayOfWeek = $dateComponents['wday'];

	//get current date

	//ranim part
	$dateToday = date('Y-m-d');

	//new
	//$dateToday = date('d/m/Y');

	//creating html table
	$calendar = "<table class = 'table table-bordered'>";
	$calendar .= "<center><h2>$monthName $year</h2></center>";

	$calendar .= "<a class='btn btn-xs btn-primary' href = '?month=".date('m', mktime(0,0,0, $month-1,1,$year))."&year=".date('Y', mktime(0,0,0, $month-1,1,$year))."'>Previous Month</a>";

	$calendar .= "<a class='btn btn-xs btn-primary' href = '?month=".date('m')."&year=".date('Y')."'>Current Month</a>";

	$calendar .= "<a class='btn btn-xs btn-primary' href = '?month=".date('m', mktime(0,0,0, $month+1,1,$year))."&year=".date('Y', mktime(0,0,0, $month+1,1,$year))."'>Next Month</a>";

	/////

	$calendar.= "<tr>";

	//creating calendar headers
	foreach ($daysOfWeek as $day) {
		# code...
		$calendar .= "<th class='header'>$day </th>";
	}

	$calendar .= "</tr><tr>";

	//only 7 columns
	if ($dayOfWeek > 0) {
		# code...
		for ($i=0; $i < $dayOfWeek; $i++) { 
			# code...
			$calendar .= "<td></td>";
		}
	}

	//initialize day counter
	$currentDay = 1;

	//get month number
	$month = str_pad($month, 2, "0", STR_PAD_LEFT);

	while ($currentDay <= $numberDays) {

		//if seventh col (saturday) reached start new row
		if ($dayOfWeek == 7) {
			# code...
			$dayOfWeek = 0;
			$calendar .= "</tr><tr>";
		}
		# code...
		$currentDayRel = str_pad($currentDay, 2, "0", STR_PAD_LEFT);

		//ranim part
		$date = "$year-$month-$currentDayRel";
		
		//new
		//$date = "$currentDayRel/$month/$year";

		$dayname = strtolower(date('l', strtotime($date)));

		$evenNum = 0;

		//ranim PART
		$today = $date ==date('Y-m-d')?"today":"";

		//new
		//$today = $date ==date('d/m/Y')?"today":"";

		if ($date < date('Y-m-d')) {
			# code...
			$calendar .= "<td><h4>$currentDay</h4> <button class='btn btn-danger btn-xs'>N/A</button>";
		}
		/*elseif (in_array($date, $selection)) {
			# code...
			$calendar.= "<td><h4>$currentDay</h4> <button class='btn btn-danger btn-xs'>Already Selected</button>";
		}*/
		else {
			$calendar .= "<td class ='$today'><h4>$currentDay</h4> <a href='select.php?date=".$date."' class='btn btn-success btn-xs'>Select</a>";
		}

		$calendar .= "</td>";

		//increase counters
		$currentDay++;
		$dayOfWeek++;
	}

	//complete the row of last week month, 
	if ($dayOfWeek != 7){
		$remainingDays = 7-$dayOfWeek;

		for ($i=0; $i < $remainingDays ; $i++) { 
			# code...
			$calendar .= "<td></td>";
		}

	}

	$calendar .= "</tr>";
	$calendar .= "</table>";

	echo $calendar;

}

?>


<!DOCTYPE html>
<html lang="en">
<head>
	<link rel="stylesheet" type="text/css" href="static/css/main.css">
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link href="https://fonts.googleapis.com/css?family=Lato:100,300,300i,400&display=swap" rel="stylesheet">
	<link rel="stylesheet" type="text/css" href="static/css/ionicons-master/docs/css/ionicons.min.css">
  	<meta charset="UTF-8">
  	<meta name="viewport" content="width=device-width,initial-scale=1,maximum-scale=1,user-scalable=no">
  	<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
  	<meta http-equiv="X-UA-Compatible" content="ie=edge">
  	<meta name="HandheldFriendly" content="true">
	 <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
	<title>Calendar</title>

	<style>
		table {
			table-layout: fixed;
		}

		td {
			width: 20;	
		}

		.today {
			background: green;
		}
	</style>
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
            <a href="logoutPage.php">Log Out</a>
          </div>
        </div>
      </nav>

    </header>
    
	<div class = "container calendar-container">
		<div class = "row">
			<div class = "col-md-12">
				<?php 
					$dateComponents = getdate();
					if (isset($_GET['month']) && isset($_GET['year'])){
						# code...
						$month = $_GET['month'];
						$year = $_GET['year'];
					}
					else{
						$month = $dateComponents['mon'];
						$year = $dateComponents['year'];	
					}
					build_calendar($month, $year);
					
				?>
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

</body>
</html>
<?php

$selectedDate = "";

if (isset($_GET['date'])) {
	# code...
	$selectedDate = $_GET['date'];
}

if (isset($_POST['submit'])) {
	# code...
	/*$username = 'dbi428501';
	$pass = '1234';
	$servername = 'studmysql01.fhict.local';
	$databaseName = 'dbi428501';

	$mysqli = new mysqli('studmysql01.fhict.local','dbi428501','1234');*/

	$EmployeeID = 39;
	$shift = $_POST['timeslot'];
	$status = 'Selected';

	require('static/php/dbConnection.php');

	$query = "INSERT INTO schedule (EmployeeID, Date, Shift, Status) VALUES ( :EmployeeID,:selectedDate,:shift,:status)";
	$stmt = $conn->prepare($query);
	$stmt->execute(
                array(
                    'EmployeeID' => $EmployeeID,
                    'selectedDate' => $selectedDate,
                    'shift' => $shift,
                    'status' => $status
                )
            );
	$msg = "<div class='alert alert-success'>Request is sent </div>";
	//$conn->close();
}

$duration = 300;
$cleanup = 0;
$start = "07:00";
$end = "22:00";

function timeslots($duration, $cleanup, $start, $end){
	$start= new DateTime($start);
	$end= new DateTime($end);
	$interval = new DateInterval("PT".$duration."M");
	$cleanupInterval = new DateInterval("PT".$cleanup."M");
	$slots = array();

	for ($intStart =$start; $intStart  < $end; $intStart->add($interval)->add($cleanupInterval)) { 
		# code...
		$endPeriod = clone $intStart;
		$endPeriod->add($interval);
		if ($endPeriod > $end) {
			# code...
			break;
		}

		$slots[] = $intStart->format("H:iA")."-".$endPeriod->format("H:iA");
	}

	return $slots;
}


?>



<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content = "ie=edge">
	<meta name="viewport" content = "width = device, initial-scale = 1.0">
	<link rel="stylesheet" type="text/css" href="static/css/main.css">

</head>
<body>

	<div class = "container">
		<h1 class="text-center">Selected Date: <?php echo date('m/d/Y', strtotime($selectedDate)); ?> </h1><hr>
		<div class = "row">
			<?php $timeslots = timeslots($duration, $cleanup, $start, $end);
				foreach ($timeslots as $ts) {
			?>
			<div class = "col-md-2">
				<div>
					<button class = "btn btn-success Select" data-timeslot = "<?php echo $ts; ?>"><?php echo $ts;?>
					</button>
				</div>
			</div>
		<?php } ?>
		</div>

		<div class="modal-header">
	        <h4 class="modal-title">Selected: <span id = "slot"></span> </h4>
	    </div>
	    <div class="modal-body">
	        <div class = "row">
	        	<div class = "col-md-12">
	        		<form action="" method="post">
	        			<div class = "form-group">
	        				<label for = ""> Timeslot</label>
	        				<input required type="text" readonly name="timeslot" id = "timeslot">
	        			</div>
	        			<div class = "form-group pull-right">
	        				<button class = "btn-primary" type = "submit" name = "submit" >Request</button>
	        			</div>
	        		</form>
	        	</div>
	        </div>
	      </div>

	</div>

	<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
	<script>
		$(".Select").click(function(){
			var timeslot = $(this).attr('data-timeslot');
			$("#slot").html(timeslot);
			$("#timeslot").val(timeslot);
			$("#myModal").modal("show");
		})
	</script>
</body>
</html>
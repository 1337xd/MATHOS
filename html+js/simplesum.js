function addNumbers()
{
		var num1 = parseInt(document.getElementById("number1").value);
		var num2 = parseInt(document.getElementById("number2").value);
		var ansD = document.getElementById("answer");
		ansD.value = num1 + num2;
}

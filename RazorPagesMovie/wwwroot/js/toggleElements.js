document.getElementById('sumButton').addEventListener('click', function() {
  var num1 = parseFloat(document.getElementById('num1').value);
  var num2 = parseFloat(document.getElementById('num2').value);
  var sum = num1 + num2;
  document.getElementById('sumResult').innerText = "Result of Sum: " + sum;
  document.getElementById('sumResult').style.display = 'block';
  document.getElementById('hideSumResultButton').style.display = 'block';
});

document.getElementById('hideSumResultButton').addEventListener('click', function() {
document.getElementById('sumResult').style.display = 'none';
document.getElementById('hideSumResultButton').style.display = 'none';
  
});


function checkTime(i) {
  if (i < 10) {
    i = "0" + i;
  }
  return i;
}

function time() {
  var date = new Date();
  var hh = date.getHours();
  var mm = date.getMinutes();
  var ss = date.getSeconds();
  
  mm = checkTime(mm);
  ss = checkTime(ss);
  document.getElementById('timescript').innerHTML = hh + ":" + mm + ":" + ss;
}
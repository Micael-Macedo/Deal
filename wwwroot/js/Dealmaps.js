var DealLatString = document.getElementById("DealLat").value;
var DealLongString = document.getElementById("DealLong").value;
DealLat = parseFloat(DealLatString)
DealLong = parseFloat(DealLongString);
const coords = { lat: DealLat, lng: DealLong};
console.log(coords);
function initMap() {
    map = new google.maps.Map(document.getElementById('gmp-map'), {
    center: coords,
    zoom: 14
  });
    marker = new google.maps.Marker({
    position: coords,
    map: map,
  });
    circle = new google.maps.Circle({
    map: map,
    radius: 100,    // 10 miles in metres
    fillColor: 'blue'
  });
  circle.bindTo('center', marker, 'position');

}

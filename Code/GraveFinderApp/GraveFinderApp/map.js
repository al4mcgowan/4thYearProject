function initialize() {
    var $latitude = '<%: Model.Latitude %>'
    var $longitude = '<%: Model.Longitude %>'
    var latitude = 53.3521648;
    var longitude = -6.2512207;
    var zoom = 15;

    var LatLng = new google.maps.LatLng(latitude, longitude);

    var mapOptions = {
        zoom: zoom,
        center: LatLng,
        panControl: false,
        zoomControl: false,
        scaleControl: true,
        mapTypeId: google.maps.MapTypeId.HYBRID
    }

    var map = new google.maps.Map(document.getElementById('mapdisplay'), mapOptions);

    var marker = new google.maps.Marker({
        position: LatLng,
        map: map,
        title: 'Drag Me!',
        draggable: false
    });

    google.maps.event.addListener(marker, 'drag', function (marker) {
        var latLng = marker.latLng;
        $latitude.value = latLng.lat().toFixed(7);
        $longitude.value = latLng.lng().toFixed(7);
    });

    google.maps.event.addListener(marker, 'dragend', function (marker) {
        var latLng = marker.latLng;
        $latitude.value = latLng.lat().toFixed(7);
        $longitude.value = latLng.lng().toFixed(7);
    });

}
initialize();
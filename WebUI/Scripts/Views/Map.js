'use strict'

mapboxgl.accessToken = 'pk.eyJ1IjoiYWxsYW5qaW1yb2QiLCJhIjoiY2p0a2hmbHEzMnZwYTQ2bXVvYmJuZ2p0OSJ9.seePR3wFt_s38LF1qpS4pQ';

let map = new mapboxgl.Map({

    container: 'map',
    style: 'mapbox://styles/mapbox/streets-v11',
    center: [-75.913597, 4.746740],
    zoom: 15
});

let element = document.createElement('div');
element.className = 'marker';

let marker = new mapboxgl.Marker(element).setLngLat({

    lng: -75.913597,
    lat: 4.746740
}).addTo(map);

map.on('click', function (e) {

    // e.lngLat is the longitude, latitude geographical position of the event
    let marker = new mapboxgl.Marker(element).setLngLat(e.lngLat).addTo(map);
    console.log(e.lngLat);
    let array = [];
    array = JSON.stringify(e.lngLat);
});
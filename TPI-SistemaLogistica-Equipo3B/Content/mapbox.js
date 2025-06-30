

mapboxgl.accessToken = 'pk.eyJ1IjoibHVsaXBheiIsImEiOiJjbWNocjN4MmQweHBtMnlwdGo5emZsMWxvIn0.uBSWATq929UTGyuyYIW_OQ'; // ¡También aquí para el lado del cliente!

const map = new mapboxgl.Map({
    container: 'map',
    style: 'mapbox://styles/mapbox/streets-v12', 
    center: [-64.1888, -31.4167],
    zoom: 4
});


map.addControl(new mapboxgl.NavigationControl());


window.drawRouteOnMap = function (routeCoordinates, startLng, startLat, endLng, endLat) {
    if (!map.isStyleLoaded()) {
        
        map.on('style.load', () => {
            _drawRoute(routeCoordinates, startLng, startLat, endLng, endLat);
        });
    } else {
        _drawRoute(routeCoordinates, startLng, startLat, endLng, endLat);
    }
};

function _drawRoute(routeCoordinates, startLng, startLat, endLng, endLat) {
    
    if (map.getSource('route')) {
        map.getSource('route').setData({
            'type': 'Feature',
            'properties': {},
            'geometry': {
                'type': 'LineString',
                'coordinates': routeCoordinates
            }
        });
    } else {
        
        map.addSource('route', {
            'type': 'geojson',
            'data': {
                'type': 'Feature',
                'properties': {},
                'geometry': {
                    'type': 'LineString',
                    'coordinates': routeCoordinates
                }
            }
        });

        map.addLayer({
            'id': 'route',
            'type': 'line',
            'source': 'route',
            'layout': {
                'line-join': 'round',
                'line-cap': 'round'
            },
            'paint': {
                'line-color': '#3887be', 
                'line-width': 8,
                'line-opacity': 0.75
            }
        });
    }

    
    if (window.startMarker) window.startMarker.remove();
    if (window.endMarker) window.endMarker.remove();

    window.startMarker = new mapboxgl.Marker()
        .setLngLat([startLng, startLat])
        .addTo(map);

    window.endMarker = new mapboxgl.Marker({ color: '#f00' }) 
        .addTo(map);


    const bounds = new mapboxgl.LngLatBounds();
    for (const coord of routeCoordinates) {
        bounds.extend(coord);
    }
    map.fitBounds(bounds, { padding: 50 }); 
}
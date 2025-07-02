
// Content/mapbox.js

mapboxgl.accessToken = 'pk.eyJ1IjoibHVsaXBheiIsImEiOiJjbWNocjN4MmQweHBtMnlwdGo5emZsMWxvIn0.uBSWATq929UTGyuyYIW_OQ';


let map;
let startMarker;
let endMarker;
let mapInitializedAndReady = false; 
let pendingRoute = null; 



document.addEventListener('DOMContentLoaded', function () {
    console.log('DOM Content Loaded. Attempting to initialize Mapbox map...');

    const mapContainer = document.getElementById('map');
    if (!mapContainer) {
        console.error("Error: El elemento con ID 'map' no se encontró en el DOM. Verifique que el ID sea correcto y que el div exista en el HTML.");
        return;
    }

    try {
        map = new mapboxgl.Map({
            container: 'map',
            style: 'mapbox://styles/mapbox/streets-v12',
            center: [-64.1888, -31.4167],
            zoom: 4
        });
        console.log('Mapbox map initialized successfully.');

        map.addControl(new mapboxgl.NavigationControl());
        console.log('Navigation Control added.');

        
        map.on('style.load', function () {
            mapInitializedAndReady = true;
            console.log('Map style loaded. Map is now fully ready.');

            
            if (pendingRoute) {
                console.log('Drawing pending route after map is ready.');
                _drawRoute(pendingRoute.coordinates, pendingRoute.startLng, pendingRoute.startLat, pendingRoute.endLng, pendingRoute.endLat);
                pendingRoute = null; 
            }
        });

    } catch (error) {
        console.error('Error during Mapbox map initialization:', error);
    }
});



window.drawRouteOnMap = function (routeCoordinates, startLng, startLat, endLng, endLat) {
    console.log('drawRouteOnMap called. Arguments:', { routeCoordinates, startLng, startLat, endLng, endLat });

    
    if (mapInitializedAndReady && map) { 
        console.log('Map is already ready, drawing route directly.');
        _drawRoute(routeCoordinates, startLng, startLat, endLng, endLat);
    } else {
       
        console.warn('Map is not yet ready. Storing route for later drawing.');
        pendingRoute = {
            coordinates: routeCoordinates,
            startLng: startLng,
            startLat: startLat,
            endLng: endLng,
            endLat: endLat
        };
      
    }
};

// Función interna para dibujar la ruta 
function _drawRoute(routeCoordinates, startLng, startLat, endLng, endLat) {
    console.log('_drawRoute executing...');

    
    if (map.getLayer('route')) {
        map.removeLayer('route');
    }
    if (map.getSource('route')) {
        map.removeSource('route');
    }

    
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

    if (startMarker) startMarker.remove();
    if (endMarker) endMarker.remove();

   
    startMarker = new mapboxgl.Marker()
        .setLngLat([startLng, startLat])
        .addTo(map);
    console.log('Start marker added at:', [startLng, startLat]);

    
    endMarker = new mapboxgl.Marker({ color: '#f00' }) 
        .setLngLat([endLng, endLat]) 
        .addTo(map);
    console.log('End marker added at:', [endLng, endLat]);



    const bounds = new mapboxgl.LngLatBounds();
    
    if (routeCoordinates && routeCoordinates.length > 0) {
        for (const coord of routeCoordinates) {
            bounds.extend(coord);
        }
    } else {
        
        console.warn('No route coordinates received, fitting bounds to markers only.');
        bounds.extend([startLng, startLat]);
        bounds.extend([endLng, endLat]);
    }

   
    map.fitBounds(bounds, { padding: 50 });
    console.log('Map fit to bounds.');
}
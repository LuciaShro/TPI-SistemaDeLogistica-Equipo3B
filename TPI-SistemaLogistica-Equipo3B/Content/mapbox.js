
// Content/mapbox.js

mapboxgl.accessToken = 'pk.eyJ1IjoibHVsaXBheiIsImEiOiJjbWNocjN4MmQweHBtMnlwdGo5emZsMWxvIn0.uBSWATq929UTGyuyYIW_OQ';

// Declarar 'map' y las variables de marcadores globalmente
let map;
let startMarker;
let endMarker;
let mapInitializedAndReady = false; // Nueva bandera para el estado del mapa
let pendingRoute = null; // Para almacenar una ruta pendiente si se llama antes de que el mapa esté listo


// Espera a que el DOM esté completamente cargado antes de inicializar el mapa
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

        // Cuando el estilo del mapa esté cargado, marcarlo como listo
        map.on('style.load', function () {
            mapInitializedAndReady = true;
            console.log('Map style loaded. Map is now fully ready.');

            // Si hay una ruta pendiente, dibujarla ahora
            if (pendingRoute) {
                console.log('Drawing pending route after map is ready.');
                _drawRoute(pendingRoute.coordinates, pendingRoute.startLng, pendingRoute.startLat, pendingRoute.endLng, pendingRoute.endLat);
                pendingRoute = null; // Limpiar la ruta pendiente
            }
        });

    } catch (error) {
        console.error('Error during Mapbox map initialization:', error);
    }
});


// Esta función debe ser global para que el código del lado del servidor (ASP.NET) pueda llamarla
window.drawRouteOnMap = function (routeCoordinates, startLng, startLat, endLng, endLat) {
    console.log('drawRouteOnMap called. Arguments:', { routeCoordinates, startLng, startLat, endLng, endLat });

    // Verificar si el mapa está completamente inicializado y listo
    if (mapInitializedAndReady && map) { // Verificamos la bandera Y que 'map' no sea null
        console.log('Map is already ready, drawing route directly.');
        _drawRoute(routeCoordinates, startLng, startLat, endLng, endLat);
    } else {
        // Si el mapa aún no está listo, almacenar la ruta y esperar
        console.warn('Map is not yet ready. Storing route for later drawing.');
        pendingRoute = {
            coordinates: routeCoordinates,
            startLng: startLng,
            startLat: startLat,
            endLng: endLng,
            endLat: endLat
        };
        // También puedes añadir un timeout de seguridad si no confías solo en style.load
        // setTimeout(() => {
        //     if (pendingRoute && mapInitializedAndReady && map) {
        //         console.log('Drawing pending route after timeout.');
        //         _drawRoute(pendingRoute.coordinates, pendingRoute.startLng, pendingRoute.startLat, pendingRoute.endLng, pendingRoute.endLat);
        //         pendingRoute = null;
        //     }
        // }, 1000); // Intenta dibujar después de 1 segundo si no se ha hecho
    }
};

// Función interna para dibujar la ruta y los marcadores
function _drawRoute(routeCoordinates, startLng, startLat, endLng, endLat) {
    console.log('_drawRoute executing...');

    // Eliminar la capa y la fuente de la ruta si ya existen
    if (map.getLayer('route')) {
        map.removeLayer('route');
    }
    if (map.getSource('route')) {
        map.removeSource('route');
    }

    // Añadir/Actualizar la fuente de la ruta
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

    // Añadir la capa de la ruta
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

    // Eliminar marcadores existentes (usando las variables globales startMarker y endMarker)
    if (startMarker) startMarker.remove();
    if (endMarker) endMarker.remove();

    // Crear y añadir el marcador de inicio
    startMarker = new mapboxgl.Marker()
        .setLngLat([startLng, startLat])
        .addTo(map);
    console.log('Start marker added at:', [startLng, startLat]);

    // Crear y añadir el marcador de destino
    endMarker = new mapboxgl.Marker({ color: '#f00' }) // Rojo
        .setLngLat([endLng, endLat]) // ¡Asegúrate de pasar las coordenadas del destino!
        .addTo(map);
    console.log('End marker added at:', [endLng, endLat]);


    // Ajustar los límites del mapa para que la ruta y los marcadores sean visibles
    const bounds = new mapboxgl.LngLatBounds();
    // Extender límites con las coordenadas de la ruta
    if (routeCoordinates && routeCoordinates.length > 0) {
        for (const coord of routeCoordinates) {
            bounds.extend(coord);
        }
    } else {
        // Si no hay coordenadas de ruta (ej. ruta no encontrada), al menos incluir los marcadores
        console.warn('No route coordinates received, fitting bounds to markers only.');
        bounds.extend([startLng, startLat]);
        bounds.extend([endLng, endLat]);
    }

    // Ajustar el mapa a los nuevos límites con un padding
    map.fitBounds(bounds, { padding: 50 });
    console.log('Map fit to bounds.');
}
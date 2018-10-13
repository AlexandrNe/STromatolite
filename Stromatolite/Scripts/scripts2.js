jQuery(document).ready(function($) {
    /********************************************/
    var myMap;

    // Дождёмся загрузки API и готовности DOM.
    ymaps.ready(init);

    function init() {

        var $map = $("#map");
        var coordinates = $map.data('coordinates').split(',');
        var title = $map.data('title');
        var title2 = $map.data('title2');
        var img = $map.data('img');

        myMap = new ymaps.Map($map[0], {
            center: [coordinates[0], coordinates[1]],
            zoom: 11
            //controls: ['smallMapDefaultSet']
        });
        myMap.behaviors.disable('scrollZoom');

        //myGeoObject = new ymaps.GeoObject({ 
        //    geometry: {
        //        type: "Point",
        //        coordinates: [coordinates[0], coordinates[1]]
        //    },
        //    properties: {
        //        iconContent: title,
        //        hintContent: '',
        //        balloonContent: '<img width="100px" class="img-thumbnail" src="' + img + '" /><p style="width:150px;">' + title2 + '</p>'
        //    }
        //}, {

        //    preset: 'islands#blueStretchyIcon'
        //});

        //myMap.geoObjects.add(myGeoObject);


    }

})
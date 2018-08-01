jQuery(document).ready(function($) {
    /********************************************/
    var myMap;

    // Дождёмся загрузки API и готовности DOM.
    ymaps.ready(init);

    function map_initialize(mapBlock) {
        mapBlock.each(function () {
            var currMap = $(this);
            var coordinates = $(this).data('coordinates').split(',');
            var title = $(this).data('title');
            var title2 = $(this).data('title2');
            var img = $(this).data('img');

            var myMap,
                myPlacemark;

            ymaps.ready(init_map);

            function init_map() {
                myMap = new ymaps.Map(currMap[0], {
                    center: [coordinates[0], coordinates[1]],
                    zoom: 11,
                    controls: ['smallMapDefaultSet']
                });
                myMap.behaviors.disable('scrollZoom');
                myGeoObject = new ymaps.GeoObject({
                    geometry: {
                        type: "Point",
                        coordinates: [coordinates[0], coordinates[1]]
                    },
                    properties: {
                        iconContent: title,
                        hintContent: '',
                        balloonContent: '<img width="100px" class="img-thumbnail" src="' + img + '" /><p style="width:150px;">' + title2 + '</p>'
                    }
                }, {
                    preset: 'islands#blueStretchyIcon'
                });

                myMap.geoObjects.add(myGeoObject)

            }
        })
    }

    function init() {

        var maps = $(".map");
        map_initialize(maps);

        //myMap = new ymaps.Map('map', {

        //    center: [54.75, 58.20], 
        //    zoom: 10
        //});

        //myMap.behaviors.disable('scrollZoom');
        //myPlacemark = new ymaps.Placemark([54.75, 58.20], {
        //    hintContent: 'ЛЕМЕЗИТ"',
        //    balloonContent: 'г. Катав-Ивановск, ул. Цементников, 7'
        //});

        //myMap.geoObjects.add(myPlacemark);

    }

})
function pathClick(e) {
    e.preventDefault();
    alert('!!!!');
    var segment = new ymaps.GeoObject({
        geometry: {
            type: "Point", // тип геометрии - точка
            coordinates: [e.coords] // координаты точки

        },
        properties: {
            iconContent: increment,
            balloonContentHeader: "Данные участка № " + (i + 1) + "",
            balloonContent: " <a type='button' href='#'  onclick='setTCODD(this)' data-toggle='modal' IdSegment=" + i + " data-target='#layoutDislocation' >Посмотреть дислокацию ТСОДД</a> <br>" +
                "<a data-toggle='modal' onclick='setRoasSings(this)'  IdSegment=" + i + " data-target='#ModalRoadSigns' href='#'>Просмотреть спецификацию знаков</a></br>" +
                "<a data-toggle='modal' onclick='setRoadBarriers(this)' data-target='#RoadBarriers' IdSegment=" + i + " href='#'>Посмотреть спецификацию дорожных ограждений</a>"
        }
    },
                    {
                        preset: "islands#blueCircleIcon"

                    });
    if (DataOfSegment[i].ChangeDislocationTCODD == true) {

        segment.options.set("preset", "islands#redCircleIcon");
    }
    myMap.geoObjects.add(segment);

    massSegment[increment - 1] = myMap.geoObjects.indexOf(segment);
    increment++;
}


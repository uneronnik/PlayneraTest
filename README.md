# PlayneraTest
Для реализации задания я решил использовать паттерн StateMachine и механику зон(PlacementZone.cs)
Роль машины состояний выполняет скрипт DraggableObject также он содержит список зон под объектом
У объекта есть 4 состояния, все состояния наследуются от класса DraggableObjectState и реализуют виртуальные методы:

LandedState - состояние спокойствия

DraggingState - состояние перетаскивания

FallingState - состояние падения

GoingToState - Объект движется к точке переданной в конструктор (Используется для реализации магнитных зон)

Все методы состояний возвращают следующее состояние для перехода (null - если нужно остаться в текущем) далее в DraggableObject
Возвращенное состояние считывается и если вернулось не null, то меняет текущее состояние

Для того, чтобы объект понимал когда он сталкивается с поверхностью есть базовый класс PlacementZone от которого наследуются все зоны. Зоны используют 2DCollider для взаимодействия с объектом
Все скрипты зон, кроме MagnetZone - пустые и ничего не делают. Они нужны для того, чтобы Объект понимал, с чем он столкнулся или где он сейчас находится для того, чтобы корректно перейти в следующее состояние

Существует 3 вида зон:

FreeFallPlacement - Зона на которой объект может остановиться только из состояния падения, другие зоны в состояние падения объект игнорирует

ManualPlacementZone - Зона в которую игрок в ручную может перенести объект

MagnetZone - Зона которая имеет отрезок на которую будут притягиваться все объекты которые пользователь отпустил над этой зоной. В инспекторе отрезок назначается двумя Transform (началом и концом)

Я решил, что в рамках тестового задания не обязательно расставлять зоны по все карте, но моя реализация позволяет это делать без особого труда. Также в CameraController.cs я реализовал скроллинг сцены. Использование StateMachine позволяет без труда расширять функционал игры, например добавление анимации.

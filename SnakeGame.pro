QT += core
QT -= gui

TARGET = SnakeGame
CONFIG += console
CONFIG -= app_bundle

TEMPLATE = app

SOURCES += main.cpp

INCLUDEPATH += E:\work\Qt\OpenCV\include
INCLUDEPATH += E:\work\Qt\OpenCV\include\opencv
INCLUDEPATH += E:\work\Qt\OpenCV\include\opencv2

LIBS += E:\work\Qt\OpenCV\lib\libopencv_calib3d2410.dll.a\
    E:\work\Qt\OpenCV\lib\libopencv_contrib2410.dll.a\
    E:\work\Qt\OpenCV\lib\libopencv_core2410.dll.a\
    E:\work\Qt\OpenCV\lib\libopencv_features2d2410.dll.a\
    E:\work\Qt\OpenCV\lib\libopencv_flann2410.dll.a\
    E:\work\Qt\OpenCV\lib\libopencv_gpu2410.dll.a\
    E:\work\Qt\OpenCV\lib\libopencv_highgui2410.dll.a\
    E:\work\Qt\OpenCV\lib\libopencv_imgproc2410.dll.a\
    E:\work\Qt\OpenCV\lib\libopencv_legacy2410.dll.a\
    E:\work\Qt\OpenCV\lib\libopencv_ml2410.dll.a\
    E:\work\Qt\OpenCV\lib\libopencv_nonfree2410.dll.a\
    E:\work\Qt\OpenCV\lib\libopencv_objdetect2410.dll.a\
    E:\work\Qt\OpenCV\lib\libopencv_ocl2410.dll.a\

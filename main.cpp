#include <QCoreApplication>
#include <cv.h>
#include "highgui.h"
#include "QVector"

using namespace cv;

QVector<Point> snakeLine;
int snakeLength=1;

Point paint(Mat &dst){
    //遍历图片
    int count,i,j;
    count=0;
    Vec3b *p;

    for(i = 0; i < dst.rows; ++i){
        p=dst.ptr<Vec3b>(i);
        for(j = 0; j < dst.cols; ++j )
        {
            if(p[j][2]>100&&p[j][1]<40&&p[j][0]<10){
                count++;
                if(count>3){
                    break;
                }
            }
        }
        if(count>3){
           // circle(dst,Point(i,j),10,Scalar( 0, 0, 255 ),-1,8);
            break;
        }
    }
    return Point(j,i);
}

void snakelong(Mat &dst,Point p){
    QVector<Point> snakeLineTemp;
    snakeLineTemp=snakeLine;
    snakeLine.insert(0,p);
    for(int a=1;a<snakeLength;a++){
        snakeLine.insert(a,snakeLineTemp.at(a-1));
        circle(dst,snakeLine.at(a),15,Scalar( 255, 0, 0 ),-1,8);
    }
}

/*
 * 这是我简单写的一个贪吃蛇游戏，貌似之前说的动作检验有点太难了，
 * 我到现在都没什么思路，打算那这个先充数。。。。
 * 我是用红色的纸片作的蛇，然后绿色的是食物
 * 将红色的纸片靠近绿色的圆，就行
 */
int main(int argc, char *argv[])
{
    QCoreApplication a(argc, argv);
    //标识，true代表要生成新的点了
    bool FLAG=true;
    //果实坐标
    int j=0,i=0;
    //存摄像头的图片
    IplImage *pFrame;
    //用于处理图片
    Mat te;
    //获取摄像头控制
    CvCapture* pCapture = cvCreateCameraCapture(0);

    while(1){
        //读入图片
        pFrame=cvQueryFrame(pCapture);
        //将te赋值
        te=(Mat)pFrame;
        //获取图片的尺寸
        Size size=te.size();
        size.width=size.width/4;
        size.height=size.height/4;

        //resize(te,te,size);
        //得到蛇的位置
        Point p=paint(te);
        //是否生成新的果实
        if(FLAG){
            i = qrand()%(te.rows-100)+50;
            j = qrand()%(te.cols-100)+50;
            FLAG=false;
        }
        circle(te,p,15,Scalar( 0, 0, 255 ),-1,8);
        circle(te,Point(j,i),15,Scalar( 0, 255, 0 ),-1,8);
        //判断蛇是否吃到果实
        if(abs(p.x-j)<15&&abs(p.y-i)<15){
            //蛇长长了
            snakeLine.append(Point(j,i));
            FLAG=true;
            snakeLength++;
        }
        snakelong(te,p);
//        imshow("te",te);

        if(waitKey(100)==27) break;
    }
    cvReleaseCapture(&pCapture);
    return a.exec();
}



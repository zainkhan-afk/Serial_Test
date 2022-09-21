#include "SimpleSerial.h"


extern "C" __declspec(dllexport) int writer_connected();
extern "C" __declspec(dllexport) int reader_connected();
extern "C" __declspec(dllexport) int file_exists();

char writer_com_port[] = "\\\\.\\COM1";
char reader_com_port[] = "\\\\.\\COM2";
DWORD COM_BAUD_RATE = CBR_9600;
SimpleSerial writer(writer_com_port, COM_BAUD_RATE);
SimpleSerial reader(reader_com_port, COM_BAUD_RATE);


int writer_connected()
{
    if (writer.connected_)
    {
        return 1;
    }
    else
    {
        return 0;
    }
}

int reader_connected()
{
    if (writer.connected_)
    {
        return 1;
    }
    else
    {
        return 0;
    }
}

int file_exists()
{
    //std::ifstream infile("C:/Zain_Dev/Serial_Test/Serial_Test_UWP/bin/x64/Debug/AppX/test.txt");
    std::ifstream infile("C:/Users/SIP/Desktop/test.txt");
    if (infile.good())
    {
        return 1;
    }
    else
    {
        return 0;
    }
}

int main()
{
    std::cout << writer_connected() << std::endl;
    std::cout << reader_connected() << std::endl;
    std::cout << file_exists() << std::endl;
    if (writer.connected_)
    {
        std::cout << "Writer Port Connected\n";
    }
    else
    {
        std::cout << "Writer Port Not Connected\n";
    }

    if (reader.connected_)
    {
        std::cout << "Reader Port Connected\n";
    }
    else
    {
        std::cout << "Reader Port Not Connected\n";
    }

    return 0;
}
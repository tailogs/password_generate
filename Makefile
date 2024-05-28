# Простой Makefile для компиляции и запуска PasswordGenerator

# Компилятор
CC = gcc
# Флаги компиляции
CFLAGS = -Wall -mwindows
# Библиотеки для линковки
LIBS = -luser32

# Файлы проекта
SRC = main.c
RES = resources.res
EXE = PasswordGenerator.exe

# Цель по умолчанию
all: $(EXE)

# Цель для компиляции приложения
$(EXE): $(SRC) $(RES)
	$(CC) $(CFLAGS) $(SRC) $(RES) -o $(EXE) $(LIBS)

# Цель для создания файла ресурсов
$(RES): resources.rc resources.h
	windres resources.rc -O coff -o $(RES)

# Цель для запуска приложения
run: $(EXE)
	.\$(EXE)
	del $(EXE) $(RES)

# Цель для удаления скомпилированных файлов
clean:
	del $(EXE) $(RES)

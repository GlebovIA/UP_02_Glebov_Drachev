-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3307
-- Время создания: Мар 14 2025 г., 19:38
-- Версия сервера: 8.0.30
-- Версия PHP: 7.2.34

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `UP02`
--
CREATE DATABASE IF NOT EXISTS `UP02` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE `UP02`;

-- --------------------------------------------------------

--
-- Структура таблицы `Absences`
--

CREATE TABLE `Absences` (
  `Id` int NOT NULL,
  `StudentId` int NOT NULL,
  `DisciplineId` int NOT NULL,
  `Date` datetime NOT NULL,
  `DelayMinutes` int NOT NULL,
  `ExplanatoryNote` varchar(1000) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Absences`
--

INSERT INTO `Absences` (`Id`, `StudentId`, `DisciplineId`, `Date`, `DelayMinutes`, `ExplanatoryNote`) VALUES
(1, 1, 1, '2023-10-01 14:00:00', 15, 'Опоздание из-за пробок'),
(2, 2, 2, '2023-10-02 15:00:00', 10, 'Опоздание по семейным обстоятельствам');

-- --------------------------------------------------------

--
-- Структура таблицы `ConsultationResults`
--

CREATE TABLE `ConsultationResults` (
  `Id` int NOT NULL,
  `ConsultationId` int NOT NULL,
  `StudentId` int NOT NULL,
  `Presence` tinyint(1) NOT NULL,
  `SubmittedPractice` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `ConsultationResults`
--

INSERT INTO `ConsultationResults` (`Id`, `ConsultationId`, `StudentId`, `Presence`, `SubmittedPractice`) VALUES
(1, 1, 1, 1, '23, 24, 27'),
(2, 2, 2, 0, 'Пришел, посидел, ушел.');

-- --------------------------------------------------------

--
-- Структура таблицы `Consultations`
--

CREATE TABLE `Consultations` (
  `Id` int NOT NULL,
  `DisciplineId` int NOT NULL,
  `Date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Consultations`
--

INSERT INTO `Consultations` (`Id`, `DisciplineId`, `Date`) VALUES
(1, 1, '2023-10-01 14:00:00'),
(2, 2, '2023-10-02 15:00:00');

-- --------------------------------------------------------

--
-- Структура таблицы `DisciplinePrograms`
--

CREATE TABLE `DisciplinePrograms` (
  `Id` int NOT NULL,
  `DisciplineId` int NOT NULL,
  `Theme` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `LessonTypeId` int NOT NULL,
  `HoursCount` int NOT NULL,
  `Completed` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `DisciplinePrograms`
--

INSERT INTO `DisciplinePrograms` (`Id`, `DisciplineId`, `Theme`, `LessonTypeId`, `HoursCount`, `Completed`) VALUES
(1, 1, 'Алгебра', 1, 10, 0),
(2, 2, 'Механика', 2, 8, 0);

-- --------------------------------------------------------

--
-- Структура таблицы `Disciplines`
--

CREATE TABLE `Disciplines` (
  `Id` int NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `TeacherId` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Disciplines`
--

INSERT INTO `Disciplines` (`Id`, `Name`, `TeacherId`) VALUES
(1, 'Математика', 1),
(2, 'Физика', 1);

-- --------------------------------------------------------

--
-- Структура таблицы `Lessons`
--

CREATE TABLE `Lessons` (
  `Id` int NOT NULL,
  `DisciplineProgramId` int NOT NULL,
  `StudGroupId` int NOT NULL,
  `Time` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `LessonTypes`
--

CREATE TABLE `LessonTypes` (
  `Id` int NOT NULL,
  `TypeName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `LessonTypes`
--

INSERT INTO `LessonTypes` (`Id`, `TypeName`) VALUES
(1, 'Лекция'),
(2, 'Практика'),
(3, 'Экзамен');

-- --------------------------------------------------------

--
-- Структура таблицы `Marks`
--

CREATE TABLE `Marks` (
  `Id` int NOT NULL,
  `Date` datetime NOT NULL,
  `Mark` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `LessonId` int NOT NULL,
  `StudentId` int NOT NULL,
  `Description` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `Roles`
--

CREATE TABLE `Roles` (
  `Id` int NOT NULL,
  `RoleName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Roles`
--

INSERT INTO `Roles` (`Id`, `RoleName`) VALUES
(1, 'Администратор'),
(2, 'Преподаватель'),
(3, 'Студент');

-- --------------------------------------------------------

--
-- Структура таблицы `Students`
--

CREATE TABLE `Students` (
  `Id` int NOT NULL,
  `Surname` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `Lastname` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `StudGroupId` int NOT NULL,
  `DateOfRemand` datetime DEFAULT NULL,
  `UserId` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Students`
--

INSERT INTO `Students` (`Id`, `Surname`, `Name`, `Lastname`, `StudGroupId`, `DateOfRemand`, `UserId`) VALUES
(1, 'Петров', 'Петр', 'Петрович', 1, NULL, 3),
(2, 'Сидоров', 'Сидор', 'Сидорович', 2, NULL, 4);

-- --------------------------------------------------------

--
-- Структура таблицы `StudGroups`
--

CREATE TABLE `StudGroups` (
  `Id` int NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `StudGroups`
--

INSERT INTO `StudGroups` (`Id`, `Name`) VALUES
(1, 'Группа 11'),
(2, 'Группа 12');

-- --------------------------------------------------------

--
-- Структура таблицы `StudPlan`
--

CREATE TABLE `StudPlan` (
  `Id` int NOT NULL,
  `TeachersLoadId` int NOT NULL,
  `PastLectureHours` int NOT NULL,
  `PastPracticeHours` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `Teachers`
--

CREATE TABLE `Teachers` (
  `Id` int NOT NULL,
  `Surname` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `Lastname` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `UserId` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Teachers`
--

INSERT INTO `Teachers` (`Id`, `Surname`, `Name`, `Lastname`, `UserId`) VALUES
(1, 'Иванов', 'Иван', 'Иванович', 2);

-- --------------------------------------------------------

--
-- Структура таблицы `TeachersLoad`
--

CREATE TABLE `TeachersLoad` (
  `Id` int NOT NULL,
  `TeacherId` int NOT NULL,
  `DisciplineId` int NOT NULL,
  `StudGroupId` int NOT NULL,
  `LectureHours` int NOT NULL,
  `PracticeHours` int NOT NULL,
  `ExamHours` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `TeachersLoad`
--

INSERT INTO `TeachersLoad` (`Id`, `TeacherId`, `DisciplineId`, `StudGroupId`, `LectureHours`, `PracticeHours`, `ExamHours`) VALUES
(1, 1, 1, 1, 30, 20, 10),
(2, 1, 2, 2, 25, 15, 5);

-- --------------------------------------------------------

--
-- Структура таблицы `Users`
--

CREATE TABLE `Users` (
  `Id` int NOT NULL,
  `Login` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `Password` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `RoleId` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Users`
--

INSERT INTO `Users` (`Id`, `Login`, `Password`, `RoleId`) VALUES
(1, 'admin', 'admin123', 1),
(2, 'teacher1', 'teacher123', 2),
(3, 'student1', 'student123', 3),
(4, 'student2', 'student123', 3);

-- --------------------------------------------------------

--
-- Структура таблицы `__EFMigrationsHistory`
--

CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Absences`
--
ALTER TABLE `Absences`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `StudentId` (`StudentId`),
  ADD KEY `DisciplineId` (`DisciplineId`);

--
-- Индексы таблицы `ConsultationResults`
--
ALTER TABLE `ConsultationResults`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `ConsultationId` (`ConsultationId`),
  ADD KEY `StudentId` (`StudentId`);

--
-- Индексы таблицы `Consultations`
--
ALTER TABLE `Consultations`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `DisciplineId` (`DisciplineId`);

--
-- Индексы таблицы `DisciplinePrograms`
--
ALTER TABLE `DisciplinePrograms`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `DisciplineId` (`DisciplineId`),
  ADD KEY `LessonTypeId` (`LessonTypeId`);

--
-- Индексы таблицы `Disciplines`
--
ALTER TABLE `Disciplines`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `TeacherId` (`TeacherId`);

--
-- Индексы таблицы `Lessons`
--
ALTER TABLE `Lessons`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `DisciplineProgramm` (`DisciplineProgramId`),
  ADD KEY `StudGroup` (`StudGroupId`);

--
-- Индексы таблицы `LessonTypes`
--
ALTER TABLE `LessonTypes`
  ADD PRIMARY KEY (`Id`);

--
-- Индексы таблицы `Marks`
--
ALTER TABLE `Marks`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `DisciplineProgramId` (`Id`),
  ADD KEY `StudentId` (`StudentId`),
  ADD KEY `marks_ibfk_1` (`LessonId`);

--
-- Индексы таблицы `Roles`
--
ALTER TABLE `Roles`
  ADD PRIMARY KEY (`Id`);

--
-- Индексы таблицы `Students`
--
ALTER TABLE `Students`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `StudGroupId` (`StudGroupId`),
  ADD KEY `UserId` (`UserId`);

--
-- Индексы таблицы `StudGroups`
--
ALTER TABLE `StudGroups`
  ADD PRIMARY KEY (`Id`);

--
-- Индексы таблицы `StudPlan`
--
ALTER TABLE `StudPlan`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `TeachersLoadId` (`TeachersLoadId`);

--
-- Индексы таблицы `Teachers`
--
ALTER TABLE `Teachers`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `userId` (`UserId`);

--
-- Индексы таблицы `TeachersLoad`
--
ALTER TABLE `TeachersLoad`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `TeacherId` (`TeacherId`),
  ADD KEY `DisciplineId` (`DisciplineId`),
  ADD KEY `StudGroupId` (`StudGroupId`);

--
-- Индексы таблицы `Users`
--
ALTER TABLE `Users`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `Role` (`RoleId`);

--
-- Индексы таблицы `__EFMigrationsHistory`
--
ALTER TABLE `__EFMigrationsHistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `Absences`
--
ALTER TABLE `Absences`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `ConsultationResults`
--
ALTER TABLE `ConsultationResults`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `Consultations`
--
ALTER TABLE `Consultations`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `DisciplinePrograms`
--
ALTER TABLE `DisciplinePrograms`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `Disciplines`
--
ALTER TABLE `Disciplines`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `Lessons`
--
ALTER TABLE `Lessons`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `LessonTypes`
--
ALTER TABLE `LessonTypes`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `Marks`
--
ALTER TABLE `Marks`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `Roles`
--
ALTER TABLE `Roles`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `Students`
--
ALTER TABLE `Students`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `StudGroups`
--
ALTER TABLE `StudGroups`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `StudPlan`
--
ALTER TABLE `StudPlan`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `Teachers`
--
ALTER TABLE `Teachers`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT для таблицы `TeachersLoad`
--
ALTER TABLE `TeachersLoad`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `Users`
--
ALTER TABLE `Users`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `Absences`
--
ALTER TABLE `Absences`
  ADD CONSTRAINT `absences_ibfk_1` FOREIGN KEY (`StudentId`) REFERENCES `Students` (`Id`),
  ADD CONSTRAINT `absences_ibfk_2` FOREIGN KEY (`DisciplineId`) REFERENCES `Disciplines` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT;

--
-- Ограничения внешнего ключа таблицы `ConsultationResults`
--
ALTER TABLE `ConsultationResults`
  ADD CONSTRAINT `consultationresults_ibfk_1` FOREIGN KEY (`ConsultationId`) REFERENCES `Consultations` (`Id`),
  ADD CONSTRAINT `consultationresults_ibfk_2` FOREIGN KEY (`StudentId`) REFERENCES `Students` (`Id`);

--
-- Ограничения внешнего ключа таблицы `DisciplinePrograms`
--
ALTER TABLE `DisciplinePrograms`
  ADD CONSTRAINT `disciplineprograms_ibfk_1` FOREIGN KEY (`DisciplineId`) REFERENCES `Disciplines` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  ADD CONSTRAINT `disciplineprograms_ibfk_2` FOREIGN KEY (`LessonTypeId`) REFERENCES `LessonTypes` (`Id`);

--
-- Ограничения внешнего ключа таблицы `Students`
--
ALTER TABLE `Students`
  ADD CONSTRAINT `students_ibfk_1` FOREIGN KEY (`StudGroupId`) REFERENCES `StudGroups` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

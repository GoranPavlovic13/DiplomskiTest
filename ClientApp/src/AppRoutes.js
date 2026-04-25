import { Routes, Route } from "react-router-dom";
import Header from "./components/Layout/Header";
import ProgrammingLanguages from "./components/ProgrammingLanguages/ProgrammingLanguages";
import AllLectures from "./components/Lectures/AllLectures";
import UpdateLecture from "./components/Lectures/UpdateLecture";
import UpdateProgrammingLanguage from "./components/ProgrammingLanguages/UpdateProgrammingLanguage";
import AvailableLectures from "./components/Lectures/AvailableLectures";
import Login from "./Pages/Login";
import Register from "./Pages/Register";

import ProtectedRoute from "./components/Auth/ProtectedRoute";
import PublicRoute from "./components/Auth/PublicRoute";
import Test from "./components/Test/Test";

const AppRoutes = () => {
  return (
    <>
      <Header />
      <main>
        <Routes>

          <Route
            path="/login"
            element={
              <PublicRoute>
                <Login />
              </PublicRoute>
            }
          />

          <Route
            path="/register"
            element={
              <PublicRoute>
                <Register />
              </PublicRoute>
            }
          />

          <Route
            path="/"
            element={
              <ProtectedRoute>
                <ProgrammingLanguages />
              </ProtectedRoute>
            }
          />

          <Route
            path="/programming-languages"
            element={
              <ProtectedRoute>
                <ProgrammingLanguages />
              </ProtectedRoute>
            }
          />

          <Route
            path="/lectures"
            element={
              <ProtectedRoute>
                <AllLectures />
              </ProtectedRoute>
            }
          />

          <Route
            path="/edit-lecture/:id"
            element={
              <ProtectedRoute>
                <UpdateLecture />
              </ProtectedRoute>
            }
          />

          <Route
            path="/programming-languages/:id/edit"
            element={
              <ProtectedRoute>
                <UpdateProgrammingLanguage />
              </ProtectedRoute>
            }
          />

            <Route
            path="/programming-languages/:id/lectures"
            element={
              <ProtectedRoute>
                <AvailableLectures/>
              </ProtectedRoute>
            }
          />

          <Route
            path="/test/:testId"
            element={
              <ProtectedRoute>
                <Test/>
              </ProtectedRoute>
            }
          />

        </Routes>
      </main>
    </>
  );
};

export default AppRoutes;

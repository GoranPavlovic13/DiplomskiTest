import { ApolloProvider } from "@apollo/client";
import "./App.css";
import Client from "./Graphql/graphqlService/Client";
import Header from "./components/Layout/Header";
import ProgrammingLanguages from "./components/ProgrammingLanguages/ProgrammingLanguages";  
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Lectures from "./components/Lectures/Lectures";
import Test from "./components/Test/Test";
<<<<<<< HEAD
import AllLectures from "./components/Lectures/AllLectures";
import UpdateLecture from "./components/Lectures/UpdateLecture";
import UpdateProgrammingLanguage from "./components/ProgrammingLanguages/UpdateProgrammingLanguage";
=======
import AddLecture from "./components/Lectures/AddLecture";
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7

function App() {
  return (
    <ApolloProvider client={Client}>
      <Router>
        <Header></Header>
        <main>
          <Routes>
            <Route path="/" element={<ProgrammingLanguages />} />
            <Route path="/programming-languages/:id/lectures" element={<Lectures></Lectures>} />
            <Route path="/test/:testId" element={<Test />} />
<<<<<<< HEAD
            <Route path="/lectures" element={<AllLectures />} />
            <Route path="/edit-lecture/:id" element={<UpdateLecture />} />
            <Route path="/programming-languages/:id/edit" element={<UpdateProgrammingLanguage />} />
=======
            <Route path="/add-lecture" element={<AddLecture />} />
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7
          </Routes>
        </main>
      </Router>
    </ApolloProvider>
  );
}

export default App;

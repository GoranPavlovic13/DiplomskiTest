import { Fragment } from "react";
import LecturesSummary from "./LecturesSummary";
import AvailableLectures from "./AvailableLectures";

const Lectures = () => {
    return <Fragment>
        <LecturesSummary/>
        <AvailableLectures/>
    </Fragment>
};

export default Lectures;
import React from 'react';
import { Card, CardHeader, CardBody } from "react-simple-card";

const Widget = ({ title, content }) => (
    <>
        <Card className="widget">
            <CardHeader>{ title }</CardHeader>
            <CardBody>{ content }</CardBody>
        </Card>
    </>
);

export default Widget;